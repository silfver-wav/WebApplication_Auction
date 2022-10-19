using AutoMapper;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using WebApplication_Auction.Core;
using WebApplication_Auction.Core.Interfaces;

namespace WebApplication_Auction.Persistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
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
                .Where(p => p.UserName.Equals(userName))
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDb adb in auctionDbs)
            {
                Auction auction = _mapper.Map<Auction>(adb);
                result.Add(auction);   
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
            foreach(BidDb bdb in auctionDb.BidDbs)
            {
                auction.AddBid(_mapper.Map<Bid>(bdb));
            }
            return auction;
        }

        public void Add(Auction auction)
        {
            AuctionDb adb = _mapper.Map<AuctionDb>(auction);    
            _dbContext.AuctionDbs.Add(adb);
            _dbContext.SaveChanges();
        }

    }
}
