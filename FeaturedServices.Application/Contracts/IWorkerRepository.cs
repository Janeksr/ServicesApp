using FeaturedServices.Common.Models;
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
        Task<List<WorkerVM>> GetWorkers();
        Task<Worker> GetWorker(int id);
        Task<bool> CheckWorkerId(int id);
        Task<bool> UpdateWorker(WorkerVM workerVM);
        Task DeleteWorker(int id);
    }
}
