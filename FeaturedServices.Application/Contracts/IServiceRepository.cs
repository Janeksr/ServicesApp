using FeaturedServices.Common.Models.Service;
using FeaturedServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<bool> AddService(ServiceVM serviceVM);
        Task<List<ListOfServicesVM>> GetWorkersWithServices();
        Task<bool> DeleteService(int id);
        Task<ServiceEditVM> GetService(int id);
        Task<bool> UpdateService(ServiceEditVM serviceEditVM);
        Task<List<ListOfServicesVM>> GetWorkersWithServicesUser(int id);
    }
}
