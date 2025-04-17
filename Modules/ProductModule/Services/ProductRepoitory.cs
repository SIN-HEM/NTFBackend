using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Data;
using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.ProductModule.Interfaces;

namespace NIFTWebApp.Modules.ProductModule.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products.Include(p => p.Category).Include(p => p.Bids).ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products.Include(p => p.Category).Include(p => p.Bids)
                                   .FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
