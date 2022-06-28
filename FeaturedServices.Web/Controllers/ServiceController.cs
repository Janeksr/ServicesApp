using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.CompanyCreated)]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServiceVM serviceVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await serviceRepository.AddService(serviceVM))
                        return RedirectToAction("MyCompany", "Company");
                }
            }
            catch (Exception ex)
            {

            }
            return View(serviceVM);
        }

        public async Task<IActionResult> ListOfServices()
        {
            var model = await serviceRepository.GetWorkersWithServices();
            return View(model);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            if(await serviceRepository.DeleteService(id))
                return RedirectToAction("ListOfServices", "Service");
            return NotFound();
        }

        public async Task<IActionResult> EditService(int id)
        {
            var model = await serviceRepository.GetService(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(ServiceEditVM serviceEditVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await serviceRepository.UpdateService(serviceEditVM))
                    {
                        return RedirectToAction("ListOfServices", "Service");
                    }
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error.");
            }
            return View(serviceEditVM);
        }
    }
}
