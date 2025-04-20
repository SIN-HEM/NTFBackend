using NIFTWebApp.Modules.BiddingModule.DTOs;

namespace NIFTWebApp.Modules.BiddingModule.Interfaces
{
    public interface IBidService
    {
        Task<IEnumerable<BidDto>> GetBidsForProduct(int productId);
        Task<BidDto> PlaceBidAsync(CreateBidDto dto);
        Task<BidDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }

}
