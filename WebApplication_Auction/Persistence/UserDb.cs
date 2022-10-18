using System.ComponentModel.DataAnnotations;

namespace WebApplication_Auction.Persistence
{
    public class UserDb
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name  { get; set; }
    }
}
