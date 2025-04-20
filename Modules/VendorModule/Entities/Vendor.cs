using NIFTWebApp.Modules.ProductModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.VendorModule.Entities
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
