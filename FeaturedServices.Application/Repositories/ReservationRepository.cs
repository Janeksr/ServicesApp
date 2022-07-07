using AutoMapper;
using AutoMapper.QueryableExtensions;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.Reservation;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Client> _userManager;

        public ReservationRepository(ApplicationDbContext context, IMapper mapper,
            IServiceRepository serviceRepository,
            ICompanyRepository companyRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Client> userManager) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _companyRepository = companyRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<int> AddResrvation(NewReservationVM newReservationVM, string userId) //return int
        {
            var today = DateTime.Now.Date;
            if(newReservationVM.StartTime.Date > today.AddMonths(2)) return 406; 

            var serviceDuration = await _context.Services.Where(x => x.Id == newReservationVM.ServiceId).Select(x => x.Duration).FirstOrDefaultAsync();

            var duration = newReservationVM.Duration - 1;
            var reservation = _mapper.Map<Reservation>(newReservationVM);
            reservation.EndTime = newReservationVM.StartTime.AddMinutes(duration);
            reservation.ClientId = userId;

            var result = await CheckCompanyWorkerService(newReservationVM);

            if (await CheckReservationDate(reservation) && result)
            {
                await AddAsync(reservation);
                return 200;
            }
            return 409;
        }

        public async Task<IEnumerable<ReservationVM>> GetAll(int companyId, int workerId)
        {
            var reservations = await _context.Reservations
                .Where(x => x.CompanyId == companyId)
                .Where(x => x.StartTime >= DateTime.Now)
                .Where(x => x.WorkerId == workerId)
                .Where(x => x.Canceled == false)
                .ProjectTo<ReservationVM>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return reservations;
        }

        private async Task<bool> CheckReservationDate(Reservation rv)
        {
            var company = await _companyRepository.GetAsync(rv.CompanyId);
            if (company == null) return false;
            if (rv.StartTime.TimeOfDay > company.ClosingHours.TimeOfDay
                || rv.EndTime.TimeOfDay > company.ClosingHours.TimeOfDay
                || rv.StartTime.TimeOfDay < company.OpeningHours.TimeOfDay) return false;

            var isReservable = await _context.Reservations
                .Where(x => x.WorkerId == rv.WorkerId)
                .Where(x => x.Canceled == false)
                .Where(x => x.StartTime.Date == rv.StartTime.Date)
                .Select(x => new
                {
                    x.Id,
                    x.StartTime,
                    x.EndTime
                })
                .ToListAsync();

            var listOfReservationsId = new List<int>();

            foreach (var reservation in isReservable)
            {
                if (reservation.EndTime < rv.StartTime || reservation.StartTime > rv.EndTime)
                {

                }
                else
                {
                    listOfReservationsId.Add(reservation.Id);
                }
            }

            if (listOfReservationsId.Any()) return false;
            return true;
        }

        private async Task<bool> CheckCompanyWorkerService(NewReservationVM nRv)
        {
            var companyExists = await _context.Companies.Where(x => x.Id == nRv.CompanyId).AnyAsync();
            if (!companyExists) return false;

            var realtion = await _context.Workers_Services
                .Where(x => x.ServiceId == nRv.ServiceId && x.WorkerId == nRv.WorkerId)
                .Include(x => x.Worker)
                .Where(x => x.Worker.CompanyId == nRv.CompanyId)
                .AnyAsync();

            if(realtion) return true;
            return false;
        }

        public async Task<List<UserReservations>> GetUserReservations()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            var reservations = await GetReservationsByUser(user.Id);
            return reservations;
        }

        private async Task<List<UserReservations>> GetReservationsByUser(string userId)
        {
            
            var reservationData = await _context.Reservations
                .Include(x => x.Worker)
                .Include(x => x.Service)
                .ThenInclude(x => x.Company)
                .Where(x => x.ClientId == userId)
                .Select(x => new UserReservations
                {
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Duration = x.Service.Duration.TimeOfDay,
                    ServiceName = x.Service.Name,
                    WorkerName = x.Worker.Firstname + " " + x.Worker.Lastname,
                    CompanyName = x.Worker.Company.Name,
                    CompanyAddress = x.Worker.Company.StreetNameAndNumber,
                    Canceled = x.Canceled
                })
                .ToListAsync();

            return reservationData;
        }
    }
}
