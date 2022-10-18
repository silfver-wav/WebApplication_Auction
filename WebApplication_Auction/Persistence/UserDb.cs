using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.Persistence
{
    public class UserDb
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string name  { get; set; }
    }
}
