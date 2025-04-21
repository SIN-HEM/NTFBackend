using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.ProductModule.DTOs
{
    public class CreateProductDto
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal StartingPrice { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }

        public bool IsService { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int VendorId { get; set; }
    }


    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal? CurrentHighestBid { get; set; }
        public string ImageUrl { get; set; }
        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }
        public string Status { get; set; }
        public bool IsService { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } // Optional if you want to include

        public int VendorId { get; set; }
        public string VendorName { get; set; } // Optional


    }


    public class UpdateProductDto
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal StartingPrice { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }

        public bool IsService { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int VendorId { get; set; }
    }


}
