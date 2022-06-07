using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
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

namespace FeaturedServices.Application.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<Client> userManager;
        private readonly IMapper mapper;

        public CompanyRepository(ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            UserManager<Client> userManager, IMapper mapper) : base(context)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.mapper = mapper;
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
                    x.TotalServices,
                    x.Company.CompanyType.Name
                })
                .Where(x => x.TotalServices > 0)
                .Distinct()
                .ToListAsync();

            var modelList = new List<CompanyExposeVM>();
            foreach (var item in companies)
            {
                var image = await context.ImageCompanies.Where(x => x.CompanyId == item.Company.Id).Where(x => x.MainImage == true).FirstOrDefaultAsync();
                if (image != null)
                {
                    var model = new CompanyExposeVM
                    {
                        Id = item.Company.Id,
                        Name = item.Company.Name,
                        Description = item.Company.Description,
                        PhoneNumber = item.Company.PhoneNumber,
                        City = item.Company.City,
                        StreetNameAndNumber = item.Company.StreetNameAndNumber,
                        OpeningHours = item.Company.OpeningHours,
                        ClosingHours = item.Company.ClosingHours,
                        CompanyTypeName = item.Company.CompanyType.Name,
                        ImageCompanyExposeVM = new ImageCompanyExposeVM { ImageName = image.ImageName, Title = image.Title }
                    };
                    modelList.Add(model);
                }
            }

            return modelList.AsQueryable();
        }

        public async Task<CompanyExposeVM> GetCompany()
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var company = context.Companies.Include(x => x.CompanyType).Where(x => x.ClientId == user.Id).FirstOrDefault();
            if (company == null) return null;

            var servicesAssignment = context.Workers.Where(x => x.CompanyId == company.Id).Where(x => x.TotalServices > 0).Any();
            if (servicesAssignment == false) return null;

            var image = await context.ImageCompanies.Where(x => x.CompanyId == company.Id).Where(x => x.MainImage == true).FirstOrDefaultAsync();

            if (image != null)
            {
                var model = new CompanyExposeVM
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description,
                    PhoneNumber = company.PhoneNumber,
                    City = company.City,
                    StreetNameAndNumber = company.StreetNameAndNumber,
                    OpeningHours = company.OpeningHours,
                    ClosingHours = company.ClosingHours,
                    CompanyTypeName = company.CompanyType.Name,
                    ImageCompanyExposeVM = new ImageCompanyExposeVM { ImageName = image.ImageName, Title = image.Title },
                };
                return model;
            }
            return null;

        }

        public async Task<CompanyExposeVM> GetCompanyForUser(int id)
        {
            if (!context.Workers.Include(x => x.Workers_Services).Where(x => x.CompanyId == id).Any()) return null;
            var company = context.Companies.Include(x => x.CompanyType).Where(x => x.Id == id).FirstOrDefault();
            if (company == null) return null;

            var image = await context.ImageCompanies.Where(x => x.CompanyId == company.Id).Where(x => x.MainImage == true).FirstOrDefaultAsync();

            if (image != null)
            {
                var model = new CompanyExposeVM
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description,
                    PhoneNumber = company.PhoneNumber,
                    City = company.City,
                    StreetNameAndNumber = company.StreetNameAndNumber,
                    OpeningHours = company.OpeningHours,
                    ClosingHours = company.ClosingHours,
                    CompanyTypeName = company.CompanyType.Name,
                    ImageCompanyExposeVM = new ImageCompanyExposeVM { ImageName = image.ImageName, Title = image.Title },
                    ListOfServicesVMs = await GetWorkersWithServicesUser(company.Id)
                };
                return model;
            }
            return null;
        }

        public async Task<List<ListOfServicesVM>> GetWorkersWithServicesUser(int id)
        {
            var model = await context.Services.Where(x => x.CompanyId == id).ToListAsync();

            var workerServicesList = new List<ListOfServicesVM>();
            foreach (var service in model)
            {
                var workerServices = new ListOfServicesVM
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Value = service.Value,
                    Duration = service.Duration
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
