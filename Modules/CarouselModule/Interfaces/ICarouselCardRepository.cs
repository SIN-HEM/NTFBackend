using NIFTWebApp.Modules.CarouselModule.Entities;

namespace NIFTWebApp.Modules.CarouselModule.Interfaces
{
    public interface ICarouselCardRepository
    {
        Task<IEnumerable<CarouselCard>> GetAllAsync();
        Task<CarouselCard?> GetByIdAsync(int id);
        Task AddAsync(CarouselCard card);
        Task DeleteAsync(int cartID);
    }

}
