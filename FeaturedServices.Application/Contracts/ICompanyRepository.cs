using FeaturedServices.Common.Models.Company;
using FeaturedServices.Common.Models.Service;
using FeaturedServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<bool> CreateCompany(CompanyVM company);
        Task<CompanyVM> GetCompanyDetails();
        Task<bool> UpdateCompany(int id, CompanyVM company);
        Task<Company> CheckCompanyEdit();
        Task<int> GetCompanyId();
        Task<IQueryable<CompanyExposeVM>> GetAllCompanies();
        Task<CompanyClientVM> GetCompanyForUser(int id);
        Task<List<ListOfServicesVM>> GetWorkersWithServicesUser(int id);
    }
}
