using FeaturedServices.Common.Models.CompanyType;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public class CompanyVM : BaseCompanyVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zip-Code Is Required."), Display(Name = "Zip Code")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Zip Code.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Description Is Required.")]
        public string Description { get; set; }

        [Display(Name = "Choose Company Type")]
        public int CompanyTypeId { get; set; }

        public SelectList? CompanyTypes { get; set; }

        [Display(Name = "Company Type")]
        public CompanyTypeVM? CompanyType { get; set; }
    }
}
