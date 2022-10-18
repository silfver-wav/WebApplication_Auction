using WebApplication_Auction.Core;

namespace WebApplication_Auction.Viewmodels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartingBid { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                Description = auction.Description,
                StartingBid = auction.StartingBid,
                StartingDate = auction.StartingDate,
                ExpirationDate = auction.ExpirationDate
            };
        }
    }
}
