using AutoMapper;
using NIFTWebApp.Modules.BiddingModule.DTOs;
using NIFTWebApp.Modules.BiddingModule.Entities;
using NIFTWebApp.Modules.BiddingModule.Interfaces;

namespace NIFTWebApp.Modules.BiddingModule.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepo;
        private readonly IMapper _mapper;

        public BidService(IBidRepository bidRepo, IMapper mapper)
        {
            _bidRepo = bidRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BidDto>> GetBidsForProduct(int productId)
        {
            var bids = await _bidRepo.GetBidsByProductIdAsync(productId);
            return _mapper.Map<IEnumerable<BidDto>>(bids);
        }

        public async Task<BidDto> PlaceBidAsync(CreateBidDto dto)
        {
            var bid = _mapper.Map<Bid>(dto);
            bid.PlacedAt = DateTime.UtcNow; // ensure timestamp is set

            await _bidRepo.AddAsync(bid);
            return _mapper.Map<BidDto>(bid);
        }

        public async Task<BidDto?> GetByIdAsync(int id)
        {
            var bid = await _bidRepo.GetByIdAsync(id);
            return bid == null ? null : _mapper.Map<BidDto>(bid);
        }


        public async Task DeleteAsync(int id)
        {
            var bid = await _bidRepo.GetByIdAsync(id);
            if (bid == null) throw new Exception("Bid not found");

            await _bidRepo.DeleteAsync(id);
        }
    }

}
