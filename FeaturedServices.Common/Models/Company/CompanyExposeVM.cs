using FeaturedServices.Common.Models.Image;
using FeaturedServices.Common.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public class CompanyExposeVM : BaseCompanyVM
    {
        public int Id { get; set; }
        public string CompanyTypeName { get; set; }
        public ImageCompanyExposeVM ImageCompanyExposeVM { get; set; }
    }
}
