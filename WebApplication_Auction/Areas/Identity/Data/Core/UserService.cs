using ProjectApp.Core.Interfaces;
using WebApplication_Auction.Areas.Identity.Data.Core.Interfaces;
using WebApplication_Auction.Core.Interfaces;

namespace WebApplication_Auction.Areas.Identity.Data.Core
{
    public class UserService : IUserService
    {
        private IUserPersistence _userPersitence;

        public UserService(IUserPersistence userPersitence)
        {
            _userPersitence = userPersitence;
        }

        public List<User> GetAllUsers()
        {
            return _userPersitence.GetAllUsers();
        }

        public void Delete(string username)
        {
            _userPersitence.Delete(username);
        }

        public User GetByUserName(string username)
        {
            return _userPersitence.GetByUserName(username);
        }
    }
}
