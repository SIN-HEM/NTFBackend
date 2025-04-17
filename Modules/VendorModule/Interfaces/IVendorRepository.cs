using NIFTWebApp.Modules.VendorModule.Entities;

namespace NIFTWebApp.Modules.VendorModule.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllAsync();
        Task<Vendor?> GetByIdAsync(int id);
        Task AddAsync(Vendor vendor);
        Task UpdateAsync(Vendor vendor);
        Task DeleteAsync(int id);
    }
}
