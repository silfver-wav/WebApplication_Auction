using AutoMapper;
using ProjectApp.Core;
using ProjectApp.Persistence;
using WebApplication_Auction.Core.Interfaces;

namespace WebApplication_Auction.Persistence
{
    public class BidSqlPersistence : IBidPersistence, IDisposable
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;


        public BidSqlPersistence(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Bid> GetAllByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void Add(int id, Bid bid)
        {
            BidDb pdb = _mapper.Map<BidDb>(bid);
            pdb.ProjectId = id;
            _dbContext.TaskDbs.Add(pdb);
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
