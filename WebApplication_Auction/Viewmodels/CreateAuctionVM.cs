using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.Viewmodels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max lenght 128 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int StartingBid { get; set; }
    }
}
