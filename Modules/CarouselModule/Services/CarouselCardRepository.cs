using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Data;
using NIFTWebApp.Modules.BiddingModule.Entities;
using NIFTWebApp.Modules.CarouselModule.Entities;
using NIFTWebApp.Modules.CarouselModule.Interfaces;

namespace NIFTWebApp.Modules.CarouselModule.Services
{
    public class CarouselCardRepository : ICarouselCardRepository
    {
        private readonly AppDbContext _context;

        public CarouselCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarouselCard>> GetAllAsync()
        {
            return await _context.CarouselCards.ToListAsync();
        }

        public async Task<CarouselCard?> GetByIdAsync(int id)
        {
            return await _context.CarouselCards.FindAsync(id);
        }

        public async Task AddAsync(CarouselCard card)
        {
            _context.CarouselCards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cc = await _context.Bids.FindAsync(id);
            if (cc != null)
            {
                _context.Bids.Remove(cc);
                await _context.SaveChangesAsync();
            }
        }
    }

}
