using WebApplication_Auction.Areas.Identity.Data.Core;

namespace WebApplication_Auction.Areas.Identity.Data.Core.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAllUsers();

        public void Delete(string username);

        public User GetByUserName(string username);
    }
}
