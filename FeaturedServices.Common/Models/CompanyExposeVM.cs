using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class CompanyExposeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string StreetNameAndNumber { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OpeningHours { get; set; }
        public DateTime ClosingHours { get; set; }
        public string CompanyTypeName { get; set; }
        public List<ImageCompanyExposeVM> ImageCompanyExposeVMs { get; set; }
    }
}
