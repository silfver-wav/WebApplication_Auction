using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> BidDbs { get; set; }
        public DbSet<AuctionDb> AuctionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDb pdb = new AuctionDb
            {
                Id = -1, // from seed data
                Title = "Learning ASP.NET Core with MVC",
                Description = "description",
                CreatedDate = DateTime.Now,
                ExpirationDate = new DateTime(2023, 12, 12, 2, 30, 50),
                StartingPrice = 20,
                UserName = "linus.silfver@gmail.com",
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(pdb);
            
            BidDb tdb1 = new BidDb()
            {
                Id = -1,
                Amount = 50,
                LastUpdated = DateTime.Now,
                AuctionId = -1,
                UserName = "linus@kth.se"
            };
            BidDb tdb2 = new BidDb()
            {
                Id = -2,
                Amount = 100,
                LastUpdated = DateTime.Now,
                AuctionId = -1,
                UserName = "victor@kth.se"
            };
            modelBuilder.Entity<BidDb>().HasData(tdb1);
            modelBuilder.Entity<BidDb>().HasData(tdb2);
        }
    }
}
