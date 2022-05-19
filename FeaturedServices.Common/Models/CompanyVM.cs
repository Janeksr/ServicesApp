using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class CompanyVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Company Name Is Required.")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City Is Required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip-Code Is Required."), Display(Name = "Zip Code")]
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Invalid Zip Code.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Street Name And Number Is Required."), Display(Name = "Street Name And Number")]
        public string StreetNameAndNumber { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Description Is Required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Opening Hours Are Required.")]
        [Display(Name = "Opening Hours")]
        [DataType(DataType.Time)]
        public DateTime OpeningHours { get; set; }

        [Required(ErrorMessage = "Closing Hours Are Required.")]
        [DataType(DataType.Time)]
        [Display(Name = "Closing Hours")]
        public DateTime ClosingHours { get; set; }

        [Display(Name = "Choose Company Type")]
        public int CompanyTypeId { get; set; }

        public SelectList? CompanyTypes { get; set; }

        [Display(Name = "Company Type")]
        public CompanyTypeVM? CompanyType { get; set; }
    }
}
