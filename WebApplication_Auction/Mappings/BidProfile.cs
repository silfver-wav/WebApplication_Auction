using AutoMapper;
using WebApplication_Auction.Core;
using WebApplication_Auction.Persistence;

namespace WebApplication_Auction.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            CreateMap<BidDb, Bid>()
                .ReverseMap();
        }

    }
}
