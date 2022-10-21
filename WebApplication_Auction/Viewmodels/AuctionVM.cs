using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StartingPrice { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsCompleted { get; set;  }

        public static AuctionVM FromAuction(Auction project)
        {
            return new AuctionVM()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                CreatedDate = project.CreatedDate,
                ExpirationDate = project.ExpirationDate,
                StartingPrice = project.StartingPrice,
                IsCompleted = project.IsCompleted()
            };
        }
    }
}
