using NIFTWebApp.Modules.VendorModule.DTOs;

namespace NIFTWebApp.Modules.VendorModule.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDto>> GetAllAsync();
        Task<VendorDto?> GetByIdAsync(int id);
        Task<VendorDto> CreateAsync(CreateVendorDto dto);
        Task UpdateAsync(int id, UpdateVendorDto dto);
        Task DeleteAsync(int id);
    }

}
