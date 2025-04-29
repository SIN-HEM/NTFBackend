using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.UserModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.CarouselModule.Entities
{
    public class CarouselCard
    {
        [Key]
        public int CarouselId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        //public byte[] Image { get; set; } // Stored as binary (BLOB)

        public string imgURL { get; set; } 

        [MaxLength(1000)]
        public string Desc { get; set; }

        [MaxLength(50)]
        public string CouponCode { get; set; }
    }
}
