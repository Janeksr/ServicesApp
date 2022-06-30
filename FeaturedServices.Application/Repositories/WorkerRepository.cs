using AutoMapper;
using AutoMapper.QueryableExtensions;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Functions;
using FeaturedServices.Common.Models.Worker;
using FeaturedServices.Common.Models.WorkerServices;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Client> userManager;

        public WorkerRepository(ApplicationDbContext context, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Client> userManager) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task AddWorkerToCompany(WorkerVM workerVM)
        {
            var companyId = await GetCompanyId();
            var worker = mapper.Map<Worker>(workerVM);

            var key = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + worker.Lastname;


            worker.Key = RandomWorker.ComputeMd5Hash(key);
            worker.CompanyId = companyId;
            //context.Entry(companyId).State = EntityState.Detached;
            await AddAsync(worker);
        }

        public async Task<List<WorkerServicesNbVM>> GetWorkers()
        {
            var companyId = await GetCompanyId();
            var workers = await context.Workers.Where(x => x.CompanyId == companyId).ToListAsync();
            
            var workerServicesNbVM = mapper.Map<List<WorkerServicesNbVM>>(workers);
            return workerServicesNbVM;
        }

        public async Task<Worker> GetWorker(int id)
        {
            var companyId = await GetCompanyId();
            var worker = await context.Workers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker == null)
            {
                return null;
            }
            else if (worker.CompanyId != companyId)
            {
                return null;
            }
            return worker;
        }

        public async Task<bool> UpdateWorker(WorkerVM workerVM)
        {
            var worker = await GetWorker(workerVM.Id);
            if (worker == null) return false;
            worker.Firstname = workerVM.Firstname;
            worker.Lastname = workerVM.Lastname;
            await UpdateAsync(worker);
            return true;
        }

        public async Task DeleteWorker(int id)
        {
            var workerServices = context.Workers_Services.Where(x => x.WorkerId == id).ToList();
            foreach (var item in workerServices)
            {
                context.Remove(item);
            }
            context.SaveChanges();

            var worker = await GetWorker(id);
            if(worker == null)
            {
                return;
            }
            await DeleteAsync(id);
        }

        public async Task<bool> CheckWorkerId(int id)
        {
            var companyId = await GetCompanyId();
            var workerCompanyId = await context.Workers.Where(x => x.Id == id).Select(x => x.CompanyId).FirstOrDefaultAsync();
            if (workerCompanyId == 0)
            {
                return false;
            }
            else if (workerCompanyId != companyId)
            {
                return false;
            }
            return true;
        }

        public async Task<List<WorkerVM>> GetWorkers(int id)
        {
            var workers = await context.Workers.Where(x => x.CompanyId == id).ProjectTo<WorkerVM>(mapper.ConfigurationProvider).ToListAsync();
            return workers;
        }

        public async Task<int> GetCompanyId()
        {
            var userId = (await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User)).Id;
            var companyId = context.Companies.Where(q => q.ClientId == userId).Select(x => x.Id).FirstOrDefault();

            return companyId;
        }
    }
}
