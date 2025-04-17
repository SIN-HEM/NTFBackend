using NIFTWebApp.Modules.BiddingModule.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NIFTWebApp.Modules.UserModule.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, PasswordPropertyText]
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User"; // Admin, User, Vendor, etc.

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }

}
