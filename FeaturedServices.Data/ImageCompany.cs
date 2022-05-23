using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class ImageCompany
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
