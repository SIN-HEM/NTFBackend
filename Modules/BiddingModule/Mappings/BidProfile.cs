using AutoMapper;
using NIFTWebApp.Modules.BiddingModule.DTOs;
using NIFTWebApp.Modules.BiddingModule.Entities;

namespace NIFTWebApp.Modules.BiddingModule.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<Bid, BidDto>();
            CreateMap<CreateBidDto, Bid>();
        }
    }
}
