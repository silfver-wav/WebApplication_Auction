using ProjectApp.Core.Interfaces;

namespace ProjectApp.Core
{
    public class MockProjectService /* : IProjectService */
    {
        public List<Auction> GetAll()
        {
            Auction p1 = new Auction(1, "Learn ASP:NET with MVC");
            Auction p2 = new Auction(2, "Prepare for your Bachelor Thesis");
            p2.AddTask(new Core.Bid(1, "Find an interesting topic and company"));
            p2.AddTask(new Core.Bid(1, "Start a pre-study"));
            List<Auction> projects = new();
            projects.Add(p1);
            projects.Add(p2);
            return projects;
        }
    }
}
