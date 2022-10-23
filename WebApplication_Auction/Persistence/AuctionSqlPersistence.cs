using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.ViewModels;
using Bid = ProjectApp.Core.Bid;

namespace ProjectApp.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence, IDisposable
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Auction> GetAllByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
                .Where(p => p.UserName.Equals(userName)) // updated for Identity
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDb pdb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(pdb);
                result.Add(auction);
            }

            return result;
        }

        public List<Auction> GetAllBidOnByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
            .Where(p => p.UserName.Equals(userName))
            .ToList();


            List<BidDb> bidsDb = _dbContext.BidDbs.Where(p => p.UserName == userName).ToList();

            List<Auction> result = new List<Auction>();
            for (int i = 0; i < bidsDb.Count; i++)
            {
                int id = bidsDb[i].AuctionId;
                var adb = _dbContext.AuctionDbs.Where(p => p.Id == id && p.ExpirationDate.CompareTo(DateTime.Now) > 0).SingleOrDefault();
                if (adb == null)
                    continue;
                result.Add(_mapper.Map<Auction>(adb));
            }

            return result;
        }

        public Auction GetById(int id)
        {
            // eager loading
            var auctionDb = _dbContext.AuctionDbs
                .Include(p => p.BidDbs)
                .Where(p => p.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            foreach(BidDb tdb in auctionDb.BidDbs)
            {
                auction.AddBid(_mapper.Map<Bid>(tdb));
            }
            return auction;
        }

        public void Add(Auction auction)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);
            _dbContext.AuctionDbs.Add(adb);
            _dbContext.SaveChanges();
        }

        public void Update(int id, string description)
        {
             var auctionDb = _dbContext.AuctionDbs
            .Where(p => p.Id == id)
            .SingleOrDefault();

            auctionDb.Description = description;
            _dbContext.Update(auctionDb);
            _dbContext.SaveChanges();
        }

        public List<Auction> GetAllOnGoing(DateTime dateTime)
        {
            var auctionDbs = _dbContext.AuctionDbs
            .Where(p => p.ExpirationDate.CompareTo(dateTime)>0)
            .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);
            }

            return result;
        }

        public void Delete(int id)
        {
            var auctionDb = _dbContext.AuctionDbs
            .Where(p => p.Id == id)
            .SingleOrDefault();

            if (auctionDb != null)
            _dbContext.AuctionDbs.Remove(auctionDb);
            _dbContext.SaveChanges();
        }

        public void DeleteByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
            .Where(p => p.UserName.Equals(userName))
            .ToList();

            foreach (AuctionDb adb in auctionDbs)
            {
                _dbContext.AuctionDbs.Remove(adb);
            }

            _dbContext.SaveChanges();
        }

        // Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
