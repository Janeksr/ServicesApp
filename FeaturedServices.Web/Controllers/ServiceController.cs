using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public IActionResult AddService(int id)
        {
            if(id == 0) return NotFound();
            var model = new ServiceVM { WorkerId = id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServiceVM serviceVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(await serviceRepository.AddService(serviceVM))
                        return RedirectToAction("MyCompany", "Company");
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public async Task<IActionResult> ListOfServices()
        {
            var model = await serviceRepository.GetWorkersWithServices();
            return View(model);
        }
    }
}
