using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.Persistence
{
    public class UserDb
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name  { get; set; }
    }
}
