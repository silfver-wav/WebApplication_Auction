using WebApplication_Auction.Core;
using AutoMapper;
using WebApplication_Auction.Persistence;

namespace WebApplication_Auction.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionDb, Auction>()
                .ReverseMap();
        }

    }
}
