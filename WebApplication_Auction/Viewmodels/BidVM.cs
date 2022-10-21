using ProjectApp.Core;
using Bid = ProjectApp.Core.Bid;

namespace ProjectApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime LastUpdated { get; set; }

        public Status Status { get; set; }

        public static BidVM FromTask(Bid task)
        {
            return new BidVM()
            {
                Id = task.Id,
                Amount = task.Amount,
                LastUpdated = task.LastUpdated,
                Status = task.Status
            };
        }
    }
}
