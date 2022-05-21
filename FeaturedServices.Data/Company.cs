using System.ComponentModel.DataAnnotations.Schema;

namespace FeaturedServices.Data
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetNameAndNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public DateTime OpeningHours { get; set; }
        public DateTime ClosingHours { get; set; }
        public int TotalServices { get; set; } = 0;

        [ForeignKey("CompanyTypeId")]
        public CompanyType CompanyType { get; set; }
        public int CompanyTypeId { get; set; }
    }
}
