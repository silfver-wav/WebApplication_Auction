using AutoMapper;
using ProjectApp.Areas.Identity.Data;
using ProjectApp.Core;
using ProjectApp.Data;

namespace WebApplication_Auction.Areas.Identity.Data
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
    }
}
