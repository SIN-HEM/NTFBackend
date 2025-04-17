namespace NIFTWebApp.Modules.VendorModule.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<VendorDto>> GetAllAsync();
        Task<VendorDto?> GetByIdAsync(int id);
        Task<VendorDto> CreateAsync(CreateVendorDto dto);
    }
}
