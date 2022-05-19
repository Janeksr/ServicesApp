using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerRepository workerRepository;

        public WorkerController(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
        }
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorker(WorkerVM workerVM)
        {
            if (ModelState.IsValid)
            {
                await workerRepository.AddWorkerToCompany(workerVM);
                return RedirectToAction("MyCompany", nameof(Company));
            }
            return View(workerVM);
        }
    }
}
