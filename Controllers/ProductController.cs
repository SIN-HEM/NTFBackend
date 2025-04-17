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
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound(); // Fix: Ensure `product` is of a nullable reference type or check for nullability correctly.
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var created = await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ProductDto>(created));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var existingProduct = await _productService.GetByIdAsync(id);
            if (existingProduct == null) return NotFound();

            _mapper.Map(dto, existingProduct);
            await _productService.UpdateAsync(existingProduct);

            return NoContent();
        }

    }
}