using NIFTWebApp.Common.Enums;
using NIFTWebApp.Modules.BiddingModule.Entities;
using NIFTWebApp.Modules.VendorModule.Entities;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography;

namespace NIFTWebApp.Modules.ProductModule.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal StartingPrice { get; set; }
        public decimal? CurrentHighestBid { get; set; }

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        public DateTime AuctionStart { get; set; }
        public DateTime AuctionEnd { get; set; }

        public ProductStatus Status { get; set; } = ProductStatus.Pending;

        public bool IsService { get; set; } = false;

        // Category Support
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Relationships
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }

}
