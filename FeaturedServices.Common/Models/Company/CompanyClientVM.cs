using FeaturedServices.Common.Models.Service;
using FeaturedServices.Common.Models.Worker;
using FeaturedServices.Common.Models.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public class CompanyClientVM : CompanyExposeVM
    {
        public List<ServicesWithWorkerVM> ServicesWithWorkerVM { get; set; }
        public List<WorkerVM> WorkersVMs { get; set; }
    }
}
