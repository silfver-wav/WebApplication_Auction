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
        public string Desc { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        // FK
        [ForeignKey("UserId")]
        public UserDb UserDb { get; set; }

        public IEnumerable<BidDb> BidDbs { get; set; }


    }
}
