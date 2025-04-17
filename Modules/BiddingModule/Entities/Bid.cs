using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.UserModule.Entities;
using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.BiddingModule.Entities
{
    public class Bid
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;

        public bool IsWinningBid { get; set; } = false;

        // Relationships
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

}
