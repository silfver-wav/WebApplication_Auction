using ProjectApp.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Persistence
{
    public class BidDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LastUpdated { get; set; }

        [Required]
        public Status Status { get; set; }

        // FK and navigation property
        [ForeignKey("ProjectId")]
        public AuctionDb ProjectDb { get; set; }

        public int ProjectId { get; set; }
    }
}
