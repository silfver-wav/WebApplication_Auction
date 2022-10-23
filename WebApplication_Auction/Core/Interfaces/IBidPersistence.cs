using ProjectApp.Core;

namespace WebApplication_Auction.Core.Interfaces
{
    public interface IBidPersistence : IDisposable
    {
        void Add(int id, Bid bid);

        void DeleteByUserName(string userName);
    }
}
