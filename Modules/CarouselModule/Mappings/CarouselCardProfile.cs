using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NIFTWebApp.Modules.CarouselModule.DTOs;
using NIFTWebApp.Modules.CarouselModule.Entities;

namespace NIFTWebApp.Modules.CarouselModule.Mappings
{
    public class CarouselCardProfile : Profile
    {
        public CarouselCardProfile()
        {
            // Map CreateDto to Entity
        CreateMap<CreateCarouselCardDto, CarouselCard>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)); // Map byte[] Image

            // Map Entity to Dto
            CreateMap<CarouselCard, CarouselCardDto>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)); // Map byte[] Image

            CreateMap<CarouselCardDto, CarouselCard>();

            CreateMap<CarouselCard, CarouselCardResponseDto>()
    .ForMember(dest => dest.ImageBase64,
               opt => opt.MapFrom(src => Convert.ToBase64String(src.Image)));


        }
    }
}
