using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.User)]
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IActionResult> MyReservations(string? error, string? errorMsg)
        {
            var model = await _reservationRepository.GetUserReservations();
            if (error != null && errorMsg != null) ModelState.AddModelError(error, errorMsg);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelReservation(int id)
        {
            try
            {
                var result = await _reservationRepository.CancelReservation(id);
                if(result) return RedirectToAction(nameof(MyReservations));
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("MyReservations", "Reservation", new { error = "CustomError", errorMsg = "An error has occured." });
        }
    }
}
