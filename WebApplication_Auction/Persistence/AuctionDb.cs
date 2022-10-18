using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_Auction.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int StartingBid { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartingDate { get; set; }

        // FK
        [ForeignKey("UserId")]
        public UserDb UserDb { get; set; }
        public int UserId { get; set; }

        public IEnumerable<BidDb> BidDbs { get; set; } = new List<BidDb>();
    }
}
