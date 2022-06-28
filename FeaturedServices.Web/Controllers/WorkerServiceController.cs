using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.CompanyCreated)]
    public class WorkerServiceController : Controller
    {
        private readonly IWorkersServicesRepository workersServicesRepository;
        private readonly IWorkerRepository workerRepository;

        public WorkerServiceController(IWorkersServicesRepository workersServicesRepository, IWorkerRepository workerRepository)
        {
            this.workersServicesRepository = workersServicesRepository;
            this.workerRepository = workerRepository;
        }
        public async Task<IActionResult> Assignment(int id)
        {
            var worker = await workerRepository.GetWorker(id);
            if(worker == null) return RedirectToAction("MyCompany", "Company", new { error = "CustomError", errorMsg = "That's not your employee." });
            var servicesList = await workersServicesRepository.PopulateSevices(worker.Id);
            if (servicesList.Count == 0)
            {
                return RedirectToAction("MyCompany", "Company", new { error = "CustomError", errorMsg = "You do not have any services." });
            }
            if (worker == null) return NotFound();
            var model = new AssignWorkerWithServicesVM(id, servicesList, worker.Firstname, worker.Lastname);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assignment(AssignWorkerWithServicesPostVM model)
        {
            if (ModelState.IsValid)
            {
                if(!await workerRepository.CheckWorkerId(model.WorkerId)) 
                    return RedirectToAction("MyCompany", "Company", new { error = "CustomError", errorMsg = "An error has occured." });

                await workersServicesRepository.UpdateWorkerServiceAssignment(model);
            }
            return RedirectToAction("MyCompany", "Company");
        }
    }
}
