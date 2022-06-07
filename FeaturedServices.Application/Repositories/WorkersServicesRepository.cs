using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class WorkersServicesRepository : GenericRepository<Worker_Service>, IWorkersServicesRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IWorkerRepository workerRepository;
        private readonly ICompanyRepository companyRepository;

        public WorkersServicesRepository(ApplicationDbContext context, IWorkerRepository workerRepository, ICompanyRepository companyRepository) : base(context)
        {
            this.context = context;
            this.workerRepository = workerRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<List<SelectListItem>> PopulateSevices(int id)
        {
            List<SelectListItem> servicesList = new List<SelectListItem>();
            var companyId = await companyRepository.GetCompanyId();
            var services = context.Services.Where(x => x.CompanyId == companyId).Select(x => new { x.Name, x.Id }).ToList();
            var selectedServicesInDb = context.Workers_Services.Where(x => x.WorkerId == id).ToList();
            foreach (var service in services)
            {

                servicesList.Add(new SelectListItem
                {
                    Text = service.Name,
                    Value = service.Id.ToString(),
                    Selected = selectedServicesInDb.Select(x => x.ServiceId).Contains(service.Id) ? true : false
                });
            }
            return servicesList;
        }

        public async Task UpdateWorkerServiceAssignment(AssignWorkerWithServicesPostVM model)
        {
            var selectedServicesInDb = await context.Workers_Services.Where(x => x.WorkerId == model.WorkerId).ToListAsync();
            if (!selectedServicesInDb.Any())
            {
                foreach (var service in model.SelectedServices)
                {
                    var workerService = new Worker_Service { WorkerId = model.WorkerId, ServiceId = service };
                    await context.Workers_Services.AddAsync(workerService);
                }
                await context.SaveChangesAsync();
            }
            else
            {
                var test = model.SelectedServices.Except(selectedServicesInDb.Select(x => x.ServiceId));
                //The following lines are in NEW LIST but not in DB
                foreach (var item in test)
                {
                    var workerService = new Worker_Service { WorkerId = model.WorkerId, ServiceId = item };
                    await context.Workers_Services.AddAsync(workerService);
                }
                await context.SaveChangesAsync();

                var selectedServicesInDbAfterUpdate = await context.Workers_Services.Where(x => x.WorkerId == model.WorkerId).ToListAsync();
                var test2 = selectedServicesInDbAfterUpdate.Select(x => x.ServiceId).Except(model.SelectedServices);
                //The following lines are in DB but not in NEW LIST
                foreach (var item in test2)
                {
                    context.Workers_Services.Remove(selectedServicesInDbAfterUpdate.Where(x => x.ServiceId == item).First());
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
