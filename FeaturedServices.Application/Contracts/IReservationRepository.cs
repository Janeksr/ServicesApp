﻿using FeaturedServices.Common.Models.Reservation;
using FeaturedServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<IEnumerable<ReservationVM>> GetAll(int companyId, int workerId);
        Task<int> AddResrvation(NewReservationVM newReservationVM, string userId);
        Task<List<UserReservations>> GetUserReservations();
        Task<bool> CancelReservation(int reservationId);
    }
}
