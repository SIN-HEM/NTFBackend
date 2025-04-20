namespace NIFTWebApp.Modules.VendorModule.DTOs
{
    public class VendorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredAt { get; set; }

        public ICollection<ProductSummaryDto> Products { get; set; } = new List<ProductSummaryDto>();
    }


    public class ProductSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal StartingPrice { get; set; }
        public DateTime AuctionEndTime { get; set; }
    }

}
