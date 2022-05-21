using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
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
        private readonly ICompanyRepository companyRepository;
        private static Random random = new Random();

        public WorkerRepository(ApplicationDbContext context, IMapper mapper, ICompanyRepository companyRepository) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task AddWorkerToCompany(WorkerVM workerVM)
        {
            var company = await companyRepository.CheckCompanyEdit();
            var worker = mapper.Map<Worker>(workerVM);
            worker.CompanyId = company.Id;
            worker.Key = RandomString(5);
            context.Entry(company).State = EntityState.Detached;
            await AddAsync(worker);
        }

        public async Task<List<WorkerVM>> GetWorkers()
        {
            var company = await companyRepository.CheckCompanyEdit();
            var workers = await context.Workers.Where(x => x.CompanyId == company.Id).ToListAsync();
            var workerVM = mapper.Map<List<WorkerVM>>(workers);
            return workerVM;
        }

        public async Task<Worker> GetWorker(int id)
        {
            var company = await companyRepository.CheckCompanyEdit();
            var worker = await context.Workers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker == null)
            {
                return null;
            }
            else if (worker.CompanyId != company.Id)
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

        
    }
}
