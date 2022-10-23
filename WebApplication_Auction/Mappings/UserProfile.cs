using AutoMapper;
using WebApplication_Auction.Areas.Identity.Data.Core;
using WebApplication_Auction.Areas.Identity.Data.Persistence;

namespace WebApplication_Auction.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Default mapping when property names are same
            CreateMap<ProjectAppUser, User>()
                   .ReverseMap();
        }
    }
}
