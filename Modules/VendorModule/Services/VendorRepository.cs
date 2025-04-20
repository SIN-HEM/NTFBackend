using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Data;
using NIFTWebApp.Modules.VendorModule.Entities;
using NIFTWebApp.Modules.VendorModule.Interfaces;

namespace NIFTWebApp.Modules.VendorModule.Services
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _context;

        public VendorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync(bool includeProducts = false)
        {
            var query = _context.Vendors.AsQueryable();

            if (includeProducts)
                query = query.Include(v => v.Products);

            return await query.ToListAsync();
        }

        public async Task<Vendor?> GetByIdAsync(int id, bool includeProducts = false)
        {
            var query = _context.Vendors.AsQueryable();

            if (includeProducts)
                query = query.Include(v => v.Products);

            return await query.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
        }
    }

}
