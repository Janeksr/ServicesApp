using AutoMapper;
using AutoMapper.QueryableExtensions;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.CompanyType;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class CompanyTypeRepository : GenericRepository<CompanyType>, ICompanyTypeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyTypeRepository(ApplicationDbContext context, 
            IMapper mapper
            ) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompanyTypeVM>> GetAllCompanyTypes()
        {
            var model = await _context.CompanyTypes.ProjectTo<CompanyTypeVM>(_mapper.ConfigurationProvider).ToListAsync();
            return model;
        }

        public async Task<CompanyTypeVM> GetCompanyType(int id)
        {
            var model = _context.CompanyTypes.FirstOrDefault(t => t.Id == id);
            var companyTypeVM = _mapper.Map<CompanyTypeVM>(model);
            return companyTypeVM;
        }

        public async Task<SelectList> GetSelectListCompaniesTypes()
        {
            var list = new SelectList(_context.CompanyTypes, "Id", "Name");
            return list;
        }
    }
}
