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
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var company = context.Companies.Where(q => q.ClientId == user.Id).FirstOrDefault();

            if (company == null) return null;

            return company;
        }

        public async Task AddTotalServices(Worker worker)
        {
            var company = await context.Companies.Where(x => x.Id == worker.CompanyId).FirstOrDefaultAsync();
            var newNumber = company.TotalServices++;
            await UpdateAsync(company);
        }

        public async Task RemoveTotalServices(Worker worker)
        {
            var company = await context.Companies.Where(x => x.Id == worker.CompanyId).FirstOrDefaultAsync();
            var newNumber = company.TotalServices--;
            await UpdateAsync(company);
        }

        public async Task<IQueryable<CompanyExposeVM>> GetAllCompanies()
        {
            var companies = await context.Companies.Include(x => x.CompanyType).Where(x => x.TotalServices > 0).ToListAsync();
            var modelList = new List<CompanyExposeVM>();
            foreach (var company in companies)
            {
                var images = await context.ImageCompanies.Where(x => x.CompanyId == company.Id).ToListAsync();
                if(images.Count > 0)
                {
                    var imagesList = new List<ImageCompanyExposeVM>();
                    foreach (var image in images)
                    {
                        var imageExposeVM = new ImageCompanyExposeVM { Title = image.Title, ImageName = image.ImageName };
                        imagesList.Add(imageExposeVM);
                    }
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
                        ImageCompanyExposeVMs = imagesList
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

            var images = await context.ImageCompanies.Where(x => x.CompanyId == company.Id).ToListAsync();
            var imagesList = new List<ImageCompanyExposeVM>();

            foreach (var image in images)
            {
                var imageExposeVM = new ImageCompanyExposeVM { Title = image.Title, ImageName = image.ImageName };
                imagesList.Add(imageExposeVM);
            }

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
                ImageCompanyExposeVMs = imagesList
            };
            return model;
        }
    }
}
