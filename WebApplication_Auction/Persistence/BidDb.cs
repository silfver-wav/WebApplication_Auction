using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Auction.Persistence
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }


        // FK and navigation property
        [ForeignKey("AuctionId")]
        public AuctionDb AuctionDb { get; set; }

        public int AuctionId { get; set; }
    }
}
