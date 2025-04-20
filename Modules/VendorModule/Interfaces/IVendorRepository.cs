using NIFTWebApp.Modules.VendorModule.Entities;

namespace NIFTWebApp.Modules.VendorModule.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllAsync(bool includeProducts = false);
        Task<Vendor?> GetByIdAsync(int id, bool includeProducts = false);
        Task AddAsync(Vendor vendor);
        Task UpdateAsync(Vendor vendor);
        Task DeleteAsync(Vendor vendor);
    }

}
