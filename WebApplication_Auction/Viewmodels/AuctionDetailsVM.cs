using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }
        public int StartingPrice { get; set; }

        public bool IsCompleted { get; set; }

        public List<BidVM> BidsVMs { get; set; } = new();

        public string UserName { get; set; }

        public static AuctionDetailsVM FromProject(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
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
            foreach(var task in auction.Bids)
            {
                detailsVM.BidsVMs.Add(BidVM.FromBid(task));
            }

            return detailsVM;
        }
    }
}
