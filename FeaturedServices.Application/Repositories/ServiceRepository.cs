using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.Service;
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
            var companyId = await companyRepository.GetCompanyId();
            var service = mapper.Map<Service>(serviceVM);
            service.CompanyId = companyId;
            await UpdateAsync(service);
            return true;
        }

        public async Task<bool> DeleteService(int id)
        {
            var service = await GetAsync(id);
            var companyId = await companyRepository.GetCompanyId();
            if(companyId != service.CompanyId) return false;
            await DeleteAsync(id);
            return true;
        }

        public async Task<ServiceEditVM> GetService(int id)
        {
            var service = await GetAsync(id);
            var companyId = await companyRepository.GetCompanyId();
            if (companyId != service.CompanyId) return null;
            return mapper.Map<ServiceEditVM>(service);
        }

        public async Task<List<ListOfServicesVM>> GetWorkersWithServices()
        {
            var companyId = await companyRepository.GetCompanyId();

            var model = await context.Services
                .Where(x => x.CompanyId == companyId)
                .ToListAsync();

            var servicesList = new List<ListOfServicesVM>();
            foreach (var service in model)
            {
                var services = new ListOfServicesVM
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Value = service.Value,
                    Duration = service.Duration
                };
                servicesList.Add(services);
            }
            return servicesList;
        }

        public async Task<bool> UpdateService(ServiceEditVM serviceEditVM)
        {
            var service = mapper.Map<Service>(serviceEditVM);
            var companyId = await companyRepository.GetCompanyId();
            service.CompanyId = companyId;
            await UpdateAsync(service);
            return true;
        }

        public async Task<List<ListOfServicesVM>> GetWorkersWithServicesUser(int id)
        {
            var model = await context.Services.Where(x => x.CompanyId == id).ToListAsync();

            var servicesList = new List<ListOfServicesVM>();
            foreach (var service in model)
            {
                var services = new ListOfServicesVM
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Value = service.Value,
                    Duration = service.Duration
                };
                servicesList.Add(services);
            }
            return servicesList;
        }
    }
}
