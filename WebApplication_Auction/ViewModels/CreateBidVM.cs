using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.ViewModels
{
    public class CreateBidVM
    {
        [Required]
        public int Amount { get; set; }
    }
}
