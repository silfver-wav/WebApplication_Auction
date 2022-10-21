using ProjectApp.Core.Interfaces;
using System.Diagnostics;

namespace ProjectApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersitence;

        public AuctionService(IAuctionPersistence projectPersitence)
        {
            _auctionPersitence = projectPersitence;
        }   

        public List<Auction> GetAllByUserName(string userName)
        {
            return _auctionPersitence.GetAllByUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _auctionPersitence.GetById(id);
        }

        public void Add(Auction project)
        {
            // assume no bids in new project
            if (project == null || project.Id != 0) throw new InvalidDataException();
            project.CreatedDate = DateTime.Now;
            _auctionPersitence.Add(project);    
        }

        public void Update(int id, string description)
        {
            if (description == null || description.Length == 0) throw new InvalidDataException();
            _auctionPersitence.Update(id, description);
        }

        public void AddBid(int id, Bid bid)
        {
            Auction auction = GetById(id);
            if(auction.FindHighestBid() >= bid.Amount || auction.StartingPrice > bid.Amount) throw new InvalidDataException();
            bid.LastUpdated = DateTime.Now;
            _auctionPersitence.AddBid(id, bid);
        }
    }
}
