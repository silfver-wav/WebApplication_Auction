namespace ProjectApp.Core.Interfaces
{
    public interface IAuctionPersistence : IDisposable
    {
        List<Auction> GetAllByUserName(string userName);
        Auction GetById(int id);
        void Add(Auction project);

        void Update(int id, string description);

        List<Auction> GetAllOnGoing(DateTime dateTime);
    }
}
