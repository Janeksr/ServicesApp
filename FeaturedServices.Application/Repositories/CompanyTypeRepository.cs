using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.CompanyType;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class CompanyTypeRepository : GenericRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CompanyTypeRepository(ApplicationDbContext context, 
            IMapper mapper
            ) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CompanyTypeVM> GetCompanyType(int id)
        {
            var model = context.CompanyTypes.FirstOrDefault(t => t.Id == id);
            var companyTypeVM = mapper.Map<CompanyTypeVM>(model);
            return companyTypeVM;
        }

        public async Task<SelectList> GetSelectListCompaniesTypes()
        {
            var list = new SelectList(context.CompanyTypes, "Id", "Name");
            return list;
        }
    }
}
