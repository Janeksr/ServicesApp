using FeaturedServices.Common.Models.Worker;
using FeaturedServices.Common.Models.WorkerServices;
using FeaturedServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IWorkerRepository : IGenericRepository<Worker>
    {
        Task AddWorkerToCompany(WorkerVM workerVM);
        Task<List<WorkerServicesNbVM>> GetWorkers();
        Task<List<WorkerVM>> GetWorkers(int id);
        Task<Worker> GetWorker(int id);
        Task<bool> CheckWorkerId(int id);
        Task<bool> UpdateWorker(WorkerVM workerVM);
        Task DeleteWorker(int id);
    }
}
