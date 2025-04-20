using AutoMapper;
using NIFTWebApp.Modules.VendorModule.DTOs;
using NIFTWebApp.Modules.VendorModule.Entities;
using NIFTWebApp.Modules.VendorModule.Interfaces;

namespace NIFTWebApp.Modules.VendorModule.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VendorDto>> GetAllAsync()
        {
            var vendors = await _vendorRepository.GetAllAsync(includeProducts: true);
            return _mapper.Map<IEnumerable<VendorDto>>(vendors);
        }

        public async Task<VendorDto?> GetByIdAsync(int id)
        {
            var vendor = await _vendorRepository.GetByIdAsync(id, includeProducts: true);
            if (vendor == null) return null;
            return _mapper.Map<VendorDto>(vendor);
        }

        public async Task<VendorDto> CreateAsync(CreateVendorDto dto)
        {
            var vendor = _mapper.Map<Vendor>(dto);
            await _vendorRepository.AddAsync(vendor);
            return _mapper.Map<VendorDto>(vendor);
        }

        public async Task UpdateAsync(int id, UpdateVendorDto dto)
        {
            var existing = await _vendorRepository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Vendor not found");

            _mapper.Map(dto, existing);
            await _vendorRepository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _vendorRepository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Vendor not found");

            await _vendorRepository.DeleteAsync(existing);
        }
    }

}
