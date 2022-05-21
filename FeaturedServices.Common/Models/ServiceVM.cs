using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class ServiceVM
    {
        [Required]
        [Display(Name ="Service Name")]
        public string Name { get; set; }
       
        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Duration Of Service")]
        public DateTime Duration { get; set; }
        public int WorkerId { get; set; }
    }
}
