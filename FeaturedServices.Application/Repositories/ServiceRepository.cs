using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IWorkerRepository workerRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public ServiceRepository(ApplicationDbContext context, IWorkerRepository workerRepository, ICompanyRepository companyRepository, IMapper mapper) : base(context)
        {
            this.context = context;
            this.workerRepository = workerRepository;
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<bool> AddService(ServiceVM serviceVM)
        {
            var worker = await workerRepository.GetWorker(serviceVM.WorkerId);
            if (worker == null) return false;
            var service = mapper.Map<Service>(serviceVM);
            await UpdateAsync(service);
            return true;
        }

        public async Task<List<WorkerServiceVM>> GetWorkersWithServices()
        {
            var company = await companyRepository.CheckCompanyEdit();
            var model = await context.Services.Include(x => x.Worker).Where(x => x.Worker.CompanyId == company.Id).ToListAsync();
            var workerServicesList = new List<WorkerServiceVM>();
            foreach (var service in model)
            {
                var workerServices = new WorkerServiceVM
                {
                    Firstname = service.Worker.Firstname,
                    Lastname = service.Worker.Lastname,
                    Name = service.Name,
                    Description = service.Description,
                    Duration = service.Duration,
                    WorkerId = service.WorkerId
                };
                workerServicesList.Add(workerServices);
            }
            return workerServicesList;
        }
    }
}
