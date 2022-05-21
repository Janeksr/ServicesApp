using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class WorkerServiceVM
    {
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "First Name")]
        public string Lastname { get; set; }
        
        [Display(Name = "Service Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Duration Of Service")]
        public DateTime Duration { get; set; }

        public int WorkerId { get; set; }
    }
}
