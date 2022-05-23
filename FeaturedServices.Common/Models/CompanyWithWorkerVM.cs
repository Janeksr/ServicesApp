using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class CompanyWithWorkerVM
    {
        public CompanyVM companyVM { get; set; }
        public List<WorkerVM> workerVM { get; set; }
        public ImageCompanyVM imageCompanyVM { get; set; }
    }
}
