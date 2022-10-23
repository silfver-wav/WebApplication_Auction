using WebApplication_Auction.Areas.Identity.Data.Core;

namespace WebApplication_Auction.ViewModels
{
    public class UserVM
    {
        public string UserName { get; set; }

        public static UserVM FromUser(User user)
        {
            return new UserVM()
            {
                UserName = user.UserName,
            };
        }
    }
}
