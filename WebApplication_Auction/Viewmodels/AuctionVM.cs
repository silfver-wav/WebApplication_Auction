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

        public string UserName { get; set; }

        public bool IsCompleted { get; set;  }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                CreatedDate = auction.CreatedDate,
                ExpirationDate = auction.ExpirationDate,
                StartingPrice = auction.StartingPrice,
                IsCompleted = auction.IsCompleted(),
                UserName = auction.UserName
            };
        }
    }
}
