using Microsoft.AspNetCore.Mvc;
using NIFTWebApp.Modules.VendorModule.DTOs;
using NIFTWebApp.Modules.VendorModule.Interfaces;

namespace NIFTWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        // GET: api/Vendor
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendors = await _vendorService.GetAllAsync();
            return Ok(vendors);
        }

        // GET: api/Vendor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vendor = await _vendorService.GetByIdAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        // POST: api/Vendor
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVendorDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Vendor data is required.");
            }

            var vendor = await _vendorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = vendor.Id }, vendor);
        }

        // PUT: api/Vendor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVendorDto dto)
        {
            try
            {
                await _vendorService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // DELETE: api/Vendor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _vendorService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
