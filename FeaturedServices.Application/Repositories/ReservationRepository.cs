using AutoMapper;
using AutoMapper.QueryableExtensions;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.Reservation;
using FeaturedServices.Data;
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

        public ReservationRepository(ApplicationDbContext context, IMapper mapper,
            IServiceRepository serviceRepository,
            ICompanyRepository companyRepository) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _serviceRepository = serviceRepository;
            _companyRepository = companyRepository;
        }

        public async Task<bool> AddResrvation(NewReservationVM newReservationVM, string userId)
        {
            var serviceDuration = await _context.Services.Where(x => x.Id == newReservationVM.ServiceId).Select(x => x.Duration).FirstOrDefaultAsync();



            var duration = newReservationVM.Duration - 1;
            var reservation = _mapper.Map<Reservation>(newReservationVM);
            reservation.EndTime = newReservationVM.StartTime.AddMinutes(duration);
            reservation.ClientId = userId;


            if (await CheckResevation(reservation))
            {
                await AddAsync(reservation);
                return true;
            }
            return false;
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

        private async Task<bool> CheckResevation(Reservation rv)
        {
            var company = await _companyRepository.GetAsync(rv.CompanyId);
            if (company == null) return false;
            if (
                rv.StartTime.TimeOfDay > company.ClosingHours.TimeOfDay
                || rv.EndTime.TimeOfDay > company.ClosingHours.TimeOfDay
                || rv.StartTime.TimeOfDay < company.OpeningHours.TimeOfDay) return false;

            var isReservable = _context.Reservations
                .Where(x => x.WorkerId == rv.WorkerId)
                .Where(x => x.Canceled == false)
                .Where(x => x.StartTime.Date == rv.StartTime.Date)
                .Where(x => x.StartTime > rv.EndTime || x.EndTime < rv.StartTime)
                .Count();

            if (isReservable > 0) return true;

            return false;

        }
    }
}
