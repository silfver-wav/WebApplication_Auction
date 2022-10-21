using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using Bid = ProjectApp.Core.Bid;

namespace ProjectApp.Persistence
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
            /*
            var projectDbs = _dbContext.ProjectDbs
                .Where(p => p.UserName.Equals(userName)) // updated for Identity
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDb pdb in projectDbs)
            {
                Auction project = _mapper.Map<Auction>(pdb);
                result.Add(project);
            }

            return result;
            */
            var projectDbs = _dbContext.ProjectDbs
            .Where(p => p.UserName.Equals(userName)) // updated for Identity
            .ToList();


            List<BidDb> bidsDb = _dbContext.TaskDbs.Where(p => p.UserName == userName).ToList();

            List<Auction> result = new List<Auction>();
            for (int i = 0; i < bidsDb.Count; i++)
            {
                int id = bidsDb[i].ProjectId;
                var adb = _dbContext.ProjectDbs.Where(p => p.Id == id && p.ExpirationDate.CompareTo(DateTime.Now) > 0).SingleOrDefault();
                if (adb == null)
                    continue;
                result.Add(_mapper.Map<Auction>(adb));
            }

            return result;
        }

        public Auction GetById(int id)
        {
            // eager loading
            var projectDb = _dbContext.ProjectDbs
                .Include(p => p.TaskDbs)
                .Where(p => p.Id == id)
                .SingleOrDefault();

            Auction project = _mapper.Map<Auction>(projectDb);
            foreach(BidDb tdb in projectDb.TaskDbs)
            {
                project.AddTask(_mapper.Map<Bid>(tdb));
            }
            return project;
        }

        public void Add(Auction project)
        {
            AuctionDb pdb = _mapper.Map<AuctionDb>(project);
            _dbContext.ProjectDbs.Add(pdb);
            _dbContext.SaveChanges();
        }

        public void Update(int id, string description)
        {
             var auctionDb = _dbContext.ProjectDbs
            .Where(p => p.Id == id)
            .SingleOrDefault();

            auctionDb.Description = description;
            _dbContext.Update(auctionDb);
            _dbContext.SaveChanges();
        }

        public void AddBid(int id, Bid bid)
        {
            BidDb pdb = _mapper.Map<BidDb>(bid);
            pdb.ProjectId = id;
            _dbContext.TaskDbs.Add(pdb);
            _dbContext.SaveChanges();
        }

        public List<Auction> GetAllOnGoing(DateTime dateTime)
        {
            var projectDbs = _dbContext.ProjectDbs
            .Where(p => p.ExpirationDate.CompareTo(dateTime)>0) // updated for Identity
            .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb pdb in projectDbs)
            {
                Auction project = _mapper.Map<Auction>(pdb);
                result.Add(project);
            }

            return result;
        }
    }
}
