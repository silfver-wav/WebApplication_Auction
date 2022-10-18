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
            AuctionDb adb = new AuctionDb
            {
                Id = -1,
                Name = "TV",
                Desc = "OLED TV from Samsung",
                Price = 150,
                Date = DateTime.Now,
                ExDate = new DateTime(2023, 12, 12, )

            };
        }
    } 
}
