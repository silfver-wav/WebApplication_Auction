using Microsoft.EntityFrameworkCore;

namespace ProjectApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> TaskDbs { get; set; }
        public DbSet<AuctionDb> ProjectDbs { get; set; }

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
                TaskDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(pdb);
            
            BidDb tdb1 = new BidDb()
            {
                Id = -1,
                Amount = 50,
                LastUpdated = DateTime.Now,
                Status = Core.Status.IN_PROGRESS,
                ProjectId = -1, 
            };
            BidDb tdb2 = new BidDb()
            {
                Id = -2,
                Amount = 100,
                LastUpdated = DateTime.Now,
                Status = Core.Status.TO_DO,
                ProjectId = -1
            };
            modelBuilder.Entity<BidDb>().HasData(tdb1);
            modelBuilder.Entity<BidDb>().HasData(tdb2);
        }
    }
}
