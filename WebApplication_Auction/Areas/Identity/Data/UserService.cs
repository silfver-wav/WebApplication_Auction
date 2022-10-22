using ProjectApp.Core.Interfaces;
using WebApplication_Auction.Core.Interfaces;

namespace WebApplication_Auction.Areas.Identity.Data
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
    }
}
