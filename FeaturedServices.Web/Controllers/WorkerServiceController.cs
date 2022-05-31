using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeaturedServices.Web.Controllers
{
    public class WorkerServiceController : Controller
    {
        private readonly ApplicationDbContext context;

        public WorkerServiceController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Assignment()
        {
            var model = PopulateSevices();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assignment(ModelOfCheckedVals model)
        {
            if (ModelState.IsValid)
            {
                foreach (var service in model.selectedServices)
                {
                    
                    var workerService = new WorkerService { WorkerId = 1, ServiceId = service };
                    context.WorkerServices.Update(workerService);
                }
                context.SaveChanges();
            }
            return View(model);
        }

        private List<SelectListItem> PopulateSevices()
        {
            List<SelectListItem> servicesList = new List<SelectListItem>();
            var services = context.Services.Where(x => x.CompanyId == 1).Select(x => new { x.Name, x.Id }).ToList();
            foreach (var service in services)
            {
                servicesList.Add(new SelectListItem
                {
                    Text = service.Name,
                    Value = service.Id.ToString()
                });
            }
            return servicesList;
        }
        public class ModelOfCheckedVals
        {
            public List<int> selectedServices { get; set; }
        }
    }
}
