using ProjectApp.Core.Interfaces;
using System.Diagnostics;
using WebApplication_Auction.Core.Interfaces;

namespace ProjectApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersitence;
        private IBidPersistence _bidPersitence;

        public AuctionService(IAuctionPersistence projectPersitence, IBidPersistence bidPersitence)
        {
            _auctionPersitence = projectPersitence;
            _bidPersitence = bidPersitence;
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
            bid.Date = DateTime.Now;
            _bidPersitence.Add(id, bid);
        }

        public List<Auction> GetAllOnGoing()
        {
            return _auctionPersitence.GetAllOnGoing(DateTime.Now);
        }

        public void Delete(int id)
        {
            _auctionPersitence.Delete(id);
        }

        public List<Auction> GetAllBidOnByUserName(string userName)
        {
            return _auctionPersitence.GetAllBidOnByUserName(userName);
        }

        public void DeleteByUserName(string userName)
        {
            _auctionPersitence.DeleteByUserName(userName);
            _bidPersitence.DeleteByUserName(userName);
        }
    }
}
