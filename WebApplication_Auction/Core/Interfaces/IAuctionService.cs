namespace ProjectApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);

        void Add(Auction project);  

        void Update(int id, string description);

        void AddBid(int id, Bid bid);

        List<Auction> GetAllOnGoing();

        List<Auction> GetAllWonAuctions(string userName);
    }
}
