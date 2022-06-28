using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.CompanyCreated)]
    public class WorkerController : Controller
    {
        private readonly IWorkerRepository workerRepository;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public WorkerController(IWorkerRepository workerRepository, IMapper mapper, ApplicationDbContext context)
        {
            this.workerRepository = workerRepository;
            this.mapper = mapper;
            this.context = context;
        }
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorker(WorkerVM workerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await workerRepository.AddWorkerToCompany(workerVM);
                    return RedirectToAction("MyCompany", "Company");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            return View(workerVM);
        }

        public async Task<IActionResult> EditWorker(int id)
        {
            var worker = await workerRepository.GetWorker(id);
            if (worker == null)
            {
                return NotFound();
            }
            var model = mapper.Map<WorkerVM>(worker);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWorker(WorkerVM workerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await workerRepository.UpdateWorker(workerVM))
                    {
                        return RedirectToAction("MyCompany", "Company");
                    }
                    else return NotFound();
                }
            }
            catch (Exception ex)
            {
            }
            ModelState.AddModelError(string.Empty, "En error has occurred.");
            return View(workerVM);
        }

        public async Task<IActionResult> DeleteWorker(int id)
        {
            await workerRepository.DeleteWorker(id);
            return RedirectToAction("MyCompany", "Company");
        }
    }
}
