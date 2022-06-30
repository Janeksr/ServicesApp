using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Company
{
    public abstract class BaseCompanyVM
    {
        [Required(ErrorMessage = "Company Name Is Required.")]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City Is Required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street Name And Number Is Required."), Display(Name = "Street Name And Number")]
        public string StreetNameAndNumber { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Opening Hours Are Required.")]
        [Display(Name = "Opening Hours")]
        [DataType(DataType.Time)]
        public DateTime OpeningHours { get; set; }

        [Required(ErrorMessage = "Closing Hours Are Required.")]
        [DataType(DataType.Time)]
        [Display(Name = "Closing Hours")]
        public DateTime ClosingHours { get; set; }

        
    }
}
