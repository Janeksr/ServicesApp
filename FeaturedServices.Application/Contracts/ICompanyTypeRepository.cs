using FeaturedServices.Common.Models;
using FeaturedServices.Data;

namespace FeaturedServices.Application.Contracts
{
    public interface ICompanyTypeRepository : IGenericRepository<CompanyType>
    {
        Task<CompanyTypeVM> GetCompanyType(int id);
        
    }
}
