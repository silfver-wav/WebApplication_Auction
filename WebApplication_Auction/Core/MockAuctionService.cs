using System.Security.Cryptography.Pkcs;
using WebApplication_Auction.Core.Interfaces;

namespace WebApplication_Auction.Core
{
    public class MockAuctionService : IAuctionService
    {
        public List<Auction> GetAll()
        {
            DateTime expirationDate = DateTime.Now;
            Auction a1 = new Auction(1, "TV", "Samsung OLED tv", 1500, expirationDate);
            Auction a2 = new Auction(2, "Macbook Pro", "Apple Macbook Pro laptop", 3000, expirationDate);
            a1.AddBid(new Core.Bid(1, 3200));
            a2.AddBid(new Core.Bid(2, 1600));
            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            return auctions;
        }

        public Auction GetById(int id)
        {
            DateTime expirationDate = DateTime.Now;
            Auction a = new Auction(1, "TV", "Samsung OLED tv", 1500, expirationDate);
            a.AddBid(new Core.Bid(1, 3200));
            return a;
        }

        public void Add(Auction auction)
        {

        }

        public List<Auction> GetAllByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
