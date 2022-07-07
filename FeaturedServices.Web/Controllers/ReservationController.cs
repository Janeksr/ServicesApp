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


        public async Task<IActionResult> MyReservations()
        {
            var model = await _reservationRepository.GetUserReservations();
            return View(model);
        }
    }
}
