namespace NIFTWebApp.Modules.CarouselModule.DTOs
{
    // DTOs/CarouselCardDto.cs
    public class CarouselCardDto
    {
        public int CarouselId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string CouponCode { get; set; }
        public byte[] Image { get; set; } // Base64 or raw byte data
    }

    // DTOs/CreateCarouselCardDto.cs
    public class CreateCarouselCardDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string CouponCode { get; set; }
        public IFormFile Image { get; set; }
    }

    public class CarouselCardResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public string CouponCode { get; set; }

        // This is a base64-encoded string representing the image
        public string ImageBase64 { get; set; }
    }


}
