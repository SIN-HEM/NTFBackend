using NIFTWebApp.Modules.BiddingModule.Entities;

namespace NIFTWebApp.Modules.BiddingModule.Interfaces
{
    public interface IBidRepository
    {
        Task<IEnumerable<Bid>> GetBidsByProductIdAsync(int productId);
        Task<Bid?> GetByIdAsync(int bidId);
        Task AddAsync(Bid bid);
        Task DeleteAsync(int bidId);
    }
}
