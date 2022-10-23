using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Persistence
{
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int StartingPrice { get; set; }

        public List<BidDb> BidDBs { get; set; } = new List<BidDb>();
    }
}
