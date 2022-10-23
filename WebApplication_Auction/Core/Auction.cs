using NuGet.Packaging.Signing;

namespace ProjectApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StartingPrice { get; set; } 

        public string UserName { get; set; }


        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
        }

        public Auction(int id, string title, DateTime createdDate)
        {
            Id = id;
            Title = title;
            CreatedDate = createdDate;
        }

        public Auction(int id, string title)
        {
            Id = id;
            Title = title;
            CreatedDate = DateTime.Now;
        }

        public Auction() { }

        public void AddTask(Bid newTask)
        {
            _bids.Add(newTask);
            System.Diagnostics.Debug.WriteLine("Bid has been added");
            System.Diagnostics.Debug.WriteLine(_bids.Count.ToString());
        }

        public bool IsCompleted()
        {
            if (_bids.Count == 0) return true;
            return _bids.All(t => t.Status == Status.DONE);
        }

        public int FindHighestBid()
        {

            System.Diagnostics.Debug.WriteLine(_bids.Count.ToString());
            if (_bids.Count == 0)
            {
                return 0;
            }
            return _bids.Max(t => t.Amount);

        }
     

        public override string ToString()
        {
            return $"{Id}: {Title} - completed: {IsCompleted()}";
        }
    }
}
