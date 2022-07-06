using FeaturedServices.Common.Models.WorkerServices;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IWorkersServicesRepository : IGenericRepository<Worker_Service>
    {
        Task<List<SelectListItem>> PopulateSevices(int id, int companyId);
        Task UpdateWorkerServiceAssignment(AssignWorkerWithServicesPostVM model);
    }
}
