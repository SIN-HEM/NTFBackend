namespace NIFTWebApp.Modules.BiddingModule.DTOs
{
    public class CreateBidDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
    }

    public class BidDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; } // Optional
        public int UserId { get; set; }
        public string? UserName { get; set; } // Optional
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class UpdateBidDto
    {
        public decimal Amount { get; set; }
    }


}
