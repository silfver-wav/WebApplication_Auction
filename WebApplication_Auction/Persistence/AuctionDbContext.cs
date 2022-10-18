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
                Id = -1,
                Username = "user123",
                Name = "the user"
            };
            modelBuilder.Entity<UserDb>().HasData(udb);

            AuctionDb adb = new AuctionDb
            {
                Id = -1,
                Name = "TV",
                Desc = "OLED TV from Samsung",
                Price = 150,
                Date = DateTime.Now,
                ExDate = new DateTime(2023, 12, 12, 2, 30, 50),
                UserId = -1
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb1 = new BidDb()
            {
                Id = -1,
                Amount = 50,
                Date = DateTime.Now,
                AuctionId = -1
            };
            BidDb bdb2 = new BidDb()
            {
                Id = -2,
                Amount = 80,
                Date = DateTime.Now,
                AuctionId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(bdb1);
            modelBuilder.Entity<BidDb>().HasData(bdb2);
        }
    } 
}
