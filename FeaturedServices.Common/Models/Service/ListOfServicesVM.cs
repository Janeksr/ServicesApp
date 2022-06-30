using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Service
{
    public class ListOfServicesVM : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Service Name")]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Value { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Duration Of Service")]
        public DateTime Duration { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Duration.ToShortTimeString() == "00:00")
            {
                yield return new ValidationResult("The Duration Can Not Be Equal to 0.",
                    new[] { nameof(Duration) });
            }
        }
    }
}
