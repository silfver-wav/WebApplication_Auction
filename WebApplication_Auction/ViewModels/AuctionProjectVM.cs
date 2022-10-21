using System.ComponentModel.DataAnnotations;

namespace ProjectApp.ViewModels
{
    public class AuctionProjectVM
    {
        [Required]
        [StringLength(128, ErrorMessage = "Max length 128 characters")]
        public string Title { get; set; }  
    }
}
