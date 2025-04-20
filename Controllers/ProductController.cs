using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NIFTWebApp.Modules.ProductModule.DTOs;
using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.ProductModule.Interfaces;

namespace NIFTWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
    

        public ProductsController(IProductService productService)
        {
            _productService = productService;
         
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound(); // Fix: Ensure `product` is of a nullable reference type or check for nullability correctly.
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var created = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null) return NotFound();

            await _productService.UpdateAsync(id, dto); 
            return NoContent();
        }

    }
}