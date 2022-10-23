using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectApp.Core;
using ProjectApp.Persistence;
using WebApplication_Auction.Areas.Identity.Data.Core;
using WebApplication_Auction.Areas.Identity.Data.Core.Interfaces;

namespace WebApplication_Auction.Areas.Identity.Data.Persistence
{
    public class UserPersistence : IUserPersistence
    {
        private ProjectAppIdentityContext _dbContext;
        private IMapper _mapper;

        public UserPersistence(ProjectAppIdentityContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<User> GetAllUsers()
        {
            var userDbs = _dbContext.Users.ToList();

            List<User> users = new List<User>();
            foreach (ProjectAppUser udb in userDbs)
            {
                User user = _mapper.Map<User>(udb);
                users.Add(user);
            }
            return users;
        }

        public void Delete(string username)
        {
            Console.WriteLine("username: " + username);
            var userDb = _dbContext.Users
            .Where(p => p.UserName.Equals(username))
            .FirstOrDefault();

            if (userDb != null)
            {
                Console.WriteLine("User is null from username: " + username + "\n");
                _dbContext.Users.Remove(userDb);
            }


            _dbContext.SaveChanges();
        }

        public User GetByUserName(string username)
        {
            // eager loading
            var userDb = _dbContext.Users
                .Where(p => p.UserName.Equals(username))
                .SingleOrDefault();

            User user = _mapper.Map<User>(userDb);

            return user;
        }
    }
}
