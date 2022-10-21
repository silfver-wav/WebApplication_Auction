using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max lenght 128 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Max lenght 128 characters")]
        public string Description { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }


    }
}
