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
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReservationRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ReservationVM>> GetAll(int companyId, int serviceId)
        {
            var reservations = await context.Reservations
                .Where(x => x.CompanyId == companyId)
                .Where(x => x.StartTime >= DateTime.Now)
                .Where(x => x.ServiceId == serviceId)
                .ProjectTo<ReservationVM>(mapper.ConfigurationProvider)
                .ToListAsync();
            return reservations;
        }
    }
}
