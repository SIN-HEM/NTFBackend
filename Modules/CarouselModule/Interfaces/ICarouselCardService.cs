using NIFTWebApp.Modules.CarouselModule.DTOs;

namespace NIFTWebApp.Modules.CarouselModule.Interfaces
{
    public interface ICarouselCardService
    {
        Task<IEnumerable<CarouselCardDto>> GetAllAsync();
        Task<CarouselCardDto?> GetByIdAsync(int id);
        Task<CarouselCardDto> CreateAsync(CarouselCardDto dto);
        Task DeleteAsync(int id);
    }

}
