using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.Reservation;

namespace FeaturedServices.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IReservationRepository reservationRepository;

        public ReservationsController(ApplicationDbContext context, IReservationRepository reservationRepository)
        {
            _context = context;
            this.reservationRepository = reservationRepository;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}/{workerId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(int id, int workerId)
        {
            var test = await reservationRepository.GetAll(id, workerId);
            return Ok(test);
        }

        //// GET: api/Reservations/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Reservation>> GetReservation(int id)
        //{
        //    if (_context.Reservations == null)
        //    {
        //        return NotFound();
        //    }
        //    var reservation = await _context.Reservations.FindAsync(id);

        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    return reservation;
        //}

        //// PUT: api/Reservations/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        //{
        //    if (id != reservation.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(reservation).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReservationExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(NewReservationVM reservationVM)
        {
            var duration = reservationVM.Duration - 1;
            var reservation = new Reservation
            {
                ClientId = reservationVM.ClientId,
                WorkerId = reservationVM.WorkerId,
                ServiceId = reservationVM.ServiceId,
                CompanyId = reservationVM.CompanyId,
                StartTime = reservationVM.StartTime,
                EndTime = reservationVM.StartTime.AddMinutes(duration),
                Canceled = false
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return Ok(reservation);

        }

        //// DELETE: api/Reservations/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReservation(int id)
        //{
        //    if (_context.Reservations == null)
        //    {
        //        return NotFound();
        //    }
        //    var reservation = await _context.Reservations.FindAsync(id);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reservations.Remove(reservation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ReservationExists(int id)
        //{
        //    return (_context.Reservations?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
