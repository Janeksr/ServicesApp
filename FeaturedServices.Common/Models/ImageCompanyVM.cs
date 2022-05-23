using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class ImageCompanyVM
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
