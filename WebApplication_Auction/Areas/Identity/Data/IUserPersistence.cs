namespace WebApplication_Auction.Areas.Identity.Data
{
    public interface IUserPersistence
    {
        public List<User> GetAllUsers();
    }
}
