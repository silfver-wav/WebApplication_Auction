using WebApplication_Auction.Core;

namespace WebApplication_Auction.Viewmodels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartingBid { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public List<BidVM> BidVMs { get; set; } = new();
        
        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingBid = auction.StartingBid,
                StartingDate = auction.StartingDate,
                ExpirationDate = auction.ExpirationDate
            };
            foreach(var bid in auction.Bids)
            {
                detailsVM.BidVMs.Add(BidVM.FromBid(bid));
            }

            return detailsVM;
        }
    }
}
