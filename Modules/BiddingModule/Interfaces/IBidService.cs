namespace NIFTWebApp.Modules.BiddingModule.Interfaces
{
    public interface IBidService
    {
        Task<IEnumerable<BidDto>> GetBidsForProduct(int productId);
        Task<BidDto> PlaceBidAsync(CreateBidDto dto);
    }
}
