using AutoMapper;
using ProjectApp.Areas.Identity.Data;
using WebApplication_Auction.Areas.Identity.Data;

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
