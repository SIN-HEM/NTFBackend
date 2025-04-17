using NIFTWebApp.Modules.ProductModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.VendorModule.Entities
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string ContactPerson { get; set; }

        [Required, EmailAddress]
        public string ContactEmail { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
