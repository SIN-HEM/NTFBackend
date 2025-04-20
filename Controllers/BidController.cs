using Microsoft.AspNetCore.Mvc;
using NIFTWebApp.Modules.BiddingModule.DTOs;
using NIFTWebApp.Modules.BiddingModule.Interfaces;

namespace NIFTWebApp.Controllers
{
 
        [ApiController]
        [Route("api/[controller]")]
        public class BidsController : ControllerBase
        {
            private readonly IBidService _bidService;

            public BidsController(IBidService bidService)
            {
                _bidService = bidService;
            }

            // GET: api/bids/product/5
            [HttpGet("product/{productId}")]
            public async Task<IActionResult> GetBidsForProduct(int productId)
            {
                var bids = await _bidService.GetBidsForProduct(productId);
                return Ok(bids);
            }

            // GET: api/bids/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var bid = await _bidService.GetByIdAsync(id);
                if (bid == null) return NotFound();
                return Ok(bid);
            }

            // POST: api/bids
            [HttpPost]
            public async Task<IActionResult> PlaceBid([FromBody] CreateBidDto dto)
            {
                var createdBid = await _bidService.PlaceBidAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdBid.Id }, createdBid);
            }

            // DELETE: api/bids/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _bidService.DeleteAsync(id);
                return NoContent();
            }
        }
}
