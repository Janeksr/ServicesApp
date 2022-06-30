using FeaturedServices.Common.Models.Service;
using FeaturedServices.Common.Models.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public class CompanyClientVM : CompanyExposeVM
    {
        public List<ListOfServicesVM> ListOfServicesVMs { get; set; }
        public List<WorkerVM> WorkersVMs { get; set; }
    }
}
