using AutoMapper;
using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.VendorModule.DTOs;
using NIFTWebApp.Modules.VendorModule.Entities;

namespace NIFTWebApp.Modules.VendorModule.Mappings
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<Vendor, VendorDto>();
            CreateMap<CreateVendorDto, Vendor>();
            CreateMap<UpdateVendorDto, Vendor>();

            CreateMap<Product, ProductSummaryDto>();
        }
    }

}
