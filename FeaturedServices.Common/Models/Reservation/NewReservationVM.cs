using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Reservation
{
    public class NewReservationVM
    {
        [Required]
        public int WorkerId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateTime StartTime { get; set; }
    }
}
