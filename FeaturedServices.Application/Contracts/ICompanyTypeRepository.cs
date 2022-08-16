using FeaturedServices.Common.Models.CompanyType;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeaturedServices.Application.Contracts
{
    public interface ICompanyTypeRepository : IGenericRepository<CompanyType>
    {
        Task<CompanyTypeVM> GetCompanyType(int id);
        Task<SelectList> GetSelectListCompaniesTypes();
        Task<List<CompanyTypeVM>> GetAllCompanyTypes();
    }
}
