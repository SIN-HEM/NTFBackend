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
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CreateCarouselCardDto dto)
    {
        string imageUrl = null;

        // Handle image upload if provided
        if (dto.Image != null && dto.Image.Length > 0)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "carouselCards");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }

            imageUrl = $"/images/carouselCards/{fileName}";
        }
        else if (!string.IsNullOrEmpty(dto.ImgURL))
        {
            // Use the provided URL
            imageUrl = dto.ImgURL;
        }
        else
        {
            return BadRequest("Either an image file or an image URL must be provided.");
        }

        var carousel = new CarouselCardDto
        {
            Title = dto.Title,
            Desc = dto.Desc,
            CouponCode = dto.CouponCode,
            ImgURL = imageUrl
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
