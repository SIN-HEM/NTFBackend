// Controllers/CarouselCardController.cs
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NIFTWebApp.Modules.CarouselModule.DTOs;
using NIFTWebApp.Modules.CarouselModule.Interfaces;
using NIFTWebApp.Modules.CarouselModule.Entities;
using NIFTWebApp.Modules.CarouselModule.Services;

[ApiController]
[Route("api/[controller]")]
public class CarouselCardController : ControllerBase
{
    private readonly ICarouselCardService _service;

    public CarouselCardController(ICarouselCardService service)
    {
        _service = service;
     
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarouselCardDto>>> GetAll()
    {
        var cards = await _service.GetAllAsync();
        return Ok(cards);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarouselCardDto>> GetById(int id)
    {
        var card = await _service.GetByIdAsync(id);
        if (card == null) return NotFound();
        return Ok(card);
    }

    [HttpPost]
    [Consumes("multipart/form-data")] // This is necessary
    public async Task<IActionResult> Create([FromForm] CreateCarouselCardDto dto)
    {
        // Optional: Convert the image to byte[] to store in DB
        byte[] imageData = null;
        if (dto.Image != null && dto.Image.Length > 0)
        {
            using (var ms = new MemoryStream())
            {
                await dto.Image.CopyToAsync(ms);
                imageData = ms.ToArray();
            }
        }

        var carousel = new CarouselCardDto
        {
            Title = dto.Title,
            Desc = dto.Desc,
            CouponCode = dto.CouponCode,
            Image = imageData
        };

        await _service.CreateAsync(carousel);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
