using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Worker
{
    public class WorkerVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string Lastname { get; set; }
    }
}
