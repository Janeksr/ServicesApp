using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using FeaturedServices.Common.Models.Company;
using FeaturedServices.Common.Models.Service;
using FeaturedServices.Common.Models.Image;

namespace FeaturedServices.Application.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Client> userManager;
        private readonly IMapper mapper;
        private readonly IWorkerRepository workerRepository;

        public CompanyRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IWorkerRepository workerRepository,
            UserManager<Client> userManager, 
            IMapper mapper) : base(context)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
            this.workerRepository = workerRepository;
        }

        public async Task<bool> CreateCompany(CompanyVM model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var company = mapper.Map<Company>(model);
            company.ClientId = user.Id;
            await AddAsync(company);
            return true;
        }

        public async Task<CompanyVM> GetCompanyDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var company = context.Companies.Include(q => q.CompanyType).Where(q => q.ClientId == user.Id).FirstOrDefault();

            var companyVM = mapper.Map<CompanyVM>(company);
            return companyVM;
        }

        public async Task<bool> UpdateCompany(int id, CompanyVM companyVM)
        {
            var company = mapper.Map<Company>(companyVM);
            var companyCheck = await CheckCompanyEdit();
            if (companyCheck != null && companyCheck.Id == company.Id)
            {
                company.ClientId = companyCheck.ClientId;
                context.Entry(companyCheck).State = EntityState.Detached;
                await UpdateAsync(company);
                return true;
            }
            return false;
        }
        public async Task<Company> CheckCompanyEdit()
        {
            var userId = (await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User)).Id;
            var company = context.Companies.Where(q => q.ClientId == userId).FirstOrDefault();

            if (company == null) return null;

            return company;
        }

        public async Task<IQueryable<CompanyExposeVM>> GetAllCompanies()
        {

            var companies = await context.Workers.Include(x => x.Company).ThenInclude(x => x.CompanyType)
                .Select(x => new
                {
                    x.Company,
                    x.Company.CompanyType.Name
                })
                .Distinct()
                .ToListAsync();

            var modelList = new List<CompanyExposeVM>();
            foreach (var company in companies)
            {
                var image = await context.ImageCompanies
                    .Where(x => x.CompanyId == company.Company.Id)
                    .Where(x => x.MainImage == true)
                    .FirstOrDefaultAsync();

                var workers = await context.Workers
                    .Where(x => x.CompanyId == company.Company.Id)
                    .Where(x => x.TotalServices > 0)
                    .ToListAsync();


                if (image != null && workers.Count() > 0)
                {
                    var model = new CompanyExposeVM
                    {
                        Id = company.Company.Id,
                        Name = company.Company.Name,
                        PhoneNumber = company.Company.PhoneNumber,
                        City = company.Company.City,
                        StreetNameAndNumber = company.Company.StreetNameAndNumber,
                        OpeningHours = company.Company.OpeningHours,
                        ClosingHours = company.Company.ClosingHours,
                        CompanyTypeName = company.Company.CompanyType.Name,
                        ImageCompanyExposeVM = new ImageCompanyExposeVM { ImageName = image.ImageName, Title = image.Title }
                    };
                    modelList.Add(model);
                }
            }

            return modelList.AsQueryable();
        }

        public async Task<CompanyClientVM> GetCompanyForUser(int id)
        {
            if (!context.Workers.Include(x => x.Workers_Services).Where(x => x.CompanyId == id).Any()) return null;
            var company = context.Companies.Include(x => x.CompanyType).Where(x => x.Id == id).FirstOrDefault();
            if (company == null) return null;

            var image = await context.ImageCompanies.Where(x => x.CompanyId == company.Id).Where(x => x.MainImage == true).FirstOrDefaultAsync();
            if (image != null)
            {
                var model = new CompanyClientVM
                {
                    Id = company.Id,
                    Name = company.Name,
                    PhoneNumber = company.PhoneNumber,
                    City = company.City,
                    StreetNameAndNumber = company.StreetNameAndNumber,
                    OpeningHours = company.OpeningHours,
                    ClosingHours = company.ClosingHours,
                    CompanyTypeName = company.CompanyType.Name,
                    ImageCompanyExposeVM = new ImageCompanyExposeVM { ImageName = image.ImageName, Title = image.Title },
                    ServicesWithWorkerVM = await GetWorkersWithServicesUser(company.Id),
                    WorkersVMs = await workerRepository.GetWorkers(company.Id),
                };
                return model;
            }
            return null;
        }

        public async Task<List<ServicesWithWorkerVM>> GetWorkersWithServicesUser(int id)
        {
            var model = await context.Services.Where(x => x.CompanyId == id).Include(x => x.Workers_Services).ToListAsync();

            var workerServicesList = new List<ServicesWithWorkerVM>();
            foreach (var service in model)
            {
                var workerServices = new ServicesWithWorkerVM
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Value = service.Value,
                    Duration = service.Duration,
                    WorkerId = service.Workers_Services.Where(x => x.ServiceId == service.Id).Select(x => x.WorkerId).ToList()
                };
                workerServicesList.Add(workerServices);
            }
            return workerServicesList;
        }

        public async Task<int> GetCompanyId()
        {
            var userId = (await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User)).Id;
            var companyId = context.Companies.Where(q => q.ClientId == userId).Select(x => x.Id).FirstOrDefault();

            return companyId;
        }
    }
}
