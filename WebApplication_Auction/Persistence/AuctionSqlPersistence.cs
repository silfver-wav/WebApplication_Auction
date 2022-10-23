using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using System.Collections.Generic;
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
                .Include(p => p.BidDBs)
                .Where(p => p.Id == id)
                .SingleOrDefault();

            Auction project = _mapper.Map<Auction>(projectDb);
            foreach (BidDb tdb in projectDb.BidDBs)
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
            .Where(p => p.ExpirationDate.CompareTo(dateTime) > 0) // updated for Identity
            .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb pdb in projectDbs)
            {
                Auction project = _mapper.Map<Auction>(pdb);
                result.Add(project);
            }

            return result;
        }
        public List<Auction> GetAllWonAuctions(DateTime dateTime, string userName)
        {
            //Get all expired auctions
            var auctionDbs = _dbContext.ProjectDbs
            .Include(p => p.BidDBs)
            .Where(p => p.ExpirationDate.CompareTo(dateTime) <= 0) // updated for Identity
            .ToList();

            List<Auction> result = new List<Auction>();
            List<BidDb> bids = new List<BidDb>();


            //Loop over
            for (int i = 0; i < auctionDbs.Count; i++)
            {
                bids = auctionDbs[i].BidDBs;

                for (int j = 0; j < bids.Count; j++)
                {
                    int highestBid = auctionDbs[i].BidDBs.Max(p => p.Amount);
                    if (bids[j].Amount == highestBid && bids[j].UserName.Equals(userName))
                    {
                        Auction auction = _mapper.Map<Auction>(bids[j].ProjectDb);
                        result.Add(auction);
                    }
                }
               
            }
            return result;

        }
        
    }
}
