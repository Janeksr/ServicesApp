﻿using AutoMapper;
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

namespace FeaturedServices.Application.Repositories
{
    public class CompanyTypeRepository : GenericRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<Client> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CompanyTypeRepository(ApplicationDbContext context, IMapper mapper,
            UserManager<Client> userManager, IHttpContextAccessor httpContextAccessor
            ) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<CompanyTypeVM> GetCompanyType(int id)
        {
            var model = context.CompanyTypes.FirstOrDefault(t => t.Id == id);
            var companyTypeVM = mapper.Map<CompanyTypeVM>(model);
            return companyTypeVM;
        }
        
    }
}
