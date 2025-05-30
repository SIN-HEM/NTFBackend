﻿using AutoMapper;
using NIFTWebApp.Modules.CarouselModule.DTOs;
using NIFTWebApp.Modules.CarouselModule.Entities;
using NIFTWebApp.Modules.CarouselModule.Interfaces;

namespace NIFTWebApp.Modules.CarouselModule.Services
{
    public class CarouselCardService : ICarouselCardService
    {
        private readonly ICarouselCardRepository _repo;
        private readonly IMapper _mapper;

        public CarouselCardService(ICarouselCardRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarouselCardDto>> GetAllAsync()
        {
            var cards = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CarouselCardDto>>(cards);
        }

        public async Task<CarouselCardDto?> GetByIdAsync(int id)
        {
            var card = await _repo.GetByIdAsync(id);
            if (card == null)
                return null;

            return _mapper.Map<CarouselCardDto>(card);
        }

        public async Task<CarouselCardDto> CreateAsync(CarouselCardDto dto)
        {
            var entity = _mapper.Map<CarouselCard>(dto);
            await _repo.AddAsync(entity);
            return _mapper.Map<CarouselCardDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var card = await _repo.GetByIdAsync(id);
            if (card == null) throw new Exception("Carousel card not found");

            await _repo.DeleteAsync(id);
        }
    }

}
