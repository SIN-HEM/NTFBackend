using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Data;
using NIFTWebApp.Modules.BiddingModule.Entities;
using NIFTWebApp.Modules.BiddingModule.Interfaces;

namespace NIFTWebApp.Modules.BiddingModule.Services
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;

        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bid>> GetBidsByProductIdAsync(int productId) =>
            await _context.Bids
                .Where(b => b.ProductId == productId)
                .Include(b => b.User)
                .OrderByDescending(b => b.Amount)
                .ToListAsync();

        public async Task<Bid?> GetByIdAsync(int bidId) =>
            await _context.Bids.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == bidId);

        public async Task AddAsync(Bid bid)
        {
            await _context.Bids.AddAsync(bid);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bidId)
        {
            var bid = await _context.Bids.FindAsync(bidId);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
