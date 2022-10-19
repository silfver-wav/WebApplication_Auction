using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication_Auction.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> BidDbs { get; set; }
        public DbSet<AuctionDb> AuctionDbs { get; set; }
        public DbSet<UserDb> UserDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            UserDb udb = new UserDb()
            {
                UserId = -1,
                UserName = "vpero@kth.se",
                Name = "victorpero"
            };
            modelBuilder.Entity<UserDb>().HasData(udb);

            AuctionDb adb = new AuctionDb
            {
                Id = -1, //Must be !=0
                Name = "TV",
                Description = "OLED TV from Samsung",
                StartingBid = 150,
                StartingDate = DateTime.Now,
                ExpirationDate = new DateTime(2023, 12, 12, 2, 30, 50),
                UserId = -1,
                UserName = "vpero@kth.se",
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb1 = new BidDb()
            {
                Id = -1, //Must be !=0
                Amount = 50,
                Date = DateTime.Now,
                AuctionId = 1,
                UserId = -1,
            };
            BidDb bdb2 = new BidDb()
            {
                Id = -2, //Must be !=0
                Amount = 80,
                Date = DateTime.Now,
                AuctionId = -1,
                UserId = -2,
            };
           modelBuilder.Entity<BidDb>().HasData(bdb1);
           modelBuilder.Entity<BidDb>().HasData(bdb2);

        }
    } 
}
