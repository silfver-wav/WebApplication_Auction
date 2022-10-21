using ProjectApp.Core.Interfaces;
using System.Diagnostics;

namespace ProjectApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _projectPersitence;

        public AuctionService(IAuctionPersistence projectPersitence)
        {
            _projectPersitence = projectPersitence;
        }   

        public List<Auction> GetAllByUserName(string userName)
        {
            return _projectPersitence.GetAllByUserName(userName);
        }

        public Auction GetById(int id)
        {
            return _projectPersitence.GetById(id);
        }

        public void Add(Auction project)
        {
            // assume no tasks in new project
            if (project == null || project.Id != 0) throw new InvalidDataException();
            project.CreatedDate = DateTime.Now;
            _projectPersitence.Add(project);    
        }
    }
}
