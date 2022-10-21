using ProjectApp.Core;

namespace ProjectApp.ViewModels
{
    public class AuctionDetailsVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ExpirationDate { get; set; }
        public int StartingPrice { get; set; }

        public bool IsCompleted { get; set; }

        public List<BidVM> TaskVMs { get; set; } = new();

        public static AuctionDetailsVM FromProject(Auction project)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                CreatedDate = project.CreatedDate,
                ExpirationDate = project.ExpirationDate,
                StartingPrice = project.StartingPrice,
                IsCompleted = project.IsCompleted()

            };
            foreach(var task in project.Bids)
            {
                detailsVM.TaskVMs.Add(BidVM.FromTask(task));
            }

            return detailsVM;
        }
    }
}
