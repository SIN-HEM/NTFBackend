using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.CarouselModule.DTOs
{
    // DTOs/CarouselCardDto.cs
    public class CarouselCardDto
    {
        public int CarouselId { get; set; }
        public string Title { get; set; }
        public string ImgURL { get; set; }
        public string Desc { get; set; }
        public string CouponCode { get; set; }
    }

    // DTOs/CreateCarouselCardDto.cs
    public class CreateCarouselCardDto
    {
       
            [Required]
            [MaxLength(150)]
            public string Title { get; set; }

            [MaxLength(1000)]
            public string Desc { get; set; }

            [MaxLength(50)]
            public string CouponCode { get; set; }

            public IFormFile? Image { get; set; } // Optional
            public string? ImgURL { get; set; }   // Optional

    }

    public class UpdateCarouselCardDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string ImgURL { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }

        [MaxLength(50)]
        public string CouponCode { get; set; }
    }


}
