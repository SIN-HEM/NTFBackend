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
            await _bidRepo.AddAsync(bid);
            return _mapper.Map<BidDto>(bid);
        }
    }
}
