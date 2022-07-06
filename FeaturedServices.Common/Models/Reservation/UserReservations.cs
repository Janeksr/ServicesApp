using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Reservation
{
    public class UserReservations
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string ServiceName { get; set; }
        public string WorkerName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
    }
}
