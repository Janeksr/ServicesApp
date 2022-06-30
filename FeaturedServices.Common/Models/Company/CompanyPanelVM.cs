using FeaturedServices.Common.Models.Image;
using FeaturedServices.Common.Models.WorkerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public class CompanyPanelVM
    {
        public CompanyVM companyVM { get; set; }
        public List<WorkerServicesNbVM> workerVMs { get; set; }
        public ImageCompanyVM imageCompanyVM { get; set; }
        public bool HaveImage { get; set; }
    }
}
