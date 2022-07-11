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
        private readonly IReservationRepository _reservationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Client> _userManager;

        public ReservationsController(IReservationRepository reservationRepository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Client> userManager)
        {
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
                    return StatusCode(reservationResult);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return BadRequest();
        }

    }
}
