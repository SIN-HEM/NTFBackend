using AutoMapper;
using NIFTWebApp.Modules.ProductModule.DTOs;
using NIFTWebApp.Modules.ProductModule.Entities;

namespace NIFTWebApp.Modules.ProductModule.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor.CompanyName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

        }
    }
}
