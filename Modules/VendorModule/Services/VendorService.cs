using AutoMapper;
using NIFTWebApp.Modules.VendorModule.Entities;
using NIFTWebApp.Modules.VendorModule.Interfaces;

namespace NIFTWebApp.Modules.VendorModule.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repo;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendorDto>> GetAllAsync()
        {
            var vendors = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<VendorDto>>(vendors);
        }

        public async Task<VendorDto?> GetByIdAsync(int id)
        {
            var vendor = await _repo.GetByIdAsync(id);
            return _mapper.Map<VendorDto?>(vendor);
        }

        public async Task<VendorDto> CreateAsync(CreateVendorDto dto)
        {
            var vendor = _mapper.Map<Vendor>(dto);
            await _repo.AddAsync(vendor);
            return _mapper.Map<VendorDto>(vendor);
        }
    }
}
