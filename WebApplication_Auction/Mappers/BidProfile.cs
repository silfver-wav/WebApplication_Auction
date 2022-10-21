using AutoMapper;
using ProjectApp.Persistence;

namespace ProjectApp.Mappers
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            // Default mapping when property names are same
            CreateMap<BidDb, Task>()
                .ReverseMap();
        }
    }
}
