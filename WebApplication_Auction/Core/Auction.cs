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

        private List<Bid> _tasks = new List<Bid>();
        public IEnumerable<Bid> Tasks => _tasks;

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
            _tasks.Add(newTask);
        }

        public bool IsCompleted()
        {
            if (_tasks.Count == 0) return true;
            return _tasks.All(t => t.Status == Status.DONE);
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - completed: {IsCompleted()}";
        }
    }
}
