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
using Microsoft.AspNetCore.Identity;

namespace FeaturedServices.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IReservationRepository _reservationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Client> _userManager;

        public ReservationsController(ApplicationDbContext context, 
            IReservationRepository reservationRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Client> userManager)
        {
            _context = context;
            this._reservationRepository = reservationRepository;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}/{workerId}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(int id, int workerId)
        {
            var test = await _reservationRepository.GetAll(id, workerId);
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
            var user = await _userManager.GetUserAsync(_httpContextAccessor?.HttpContext?.User);
            if(user == null)
            {
                return StatusCode(401);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    var reservationResult = await _reservationRepository.AddResrvation(reservationVM, user.Id);
                    if (!reservationResult) return StatusCode(409);
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
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
