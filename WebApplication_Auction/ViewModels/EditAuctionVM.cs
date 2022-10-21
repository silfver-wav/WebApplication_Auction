using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.ViewModels
{
    public class EditAuctionVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max lenght 128 characters")]
        public string Description { get; set; }
    }
}
