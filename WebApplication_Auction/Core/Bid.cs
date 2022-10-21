namespace ProjectApp.Core
{
    public class Bid
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        private DateTime _lastUpdated;
        public DateTime LastUpdated { get; set; }

        private Status _status;

        public string UserName { get; set; }
        public Status Status
        {
            get => _status;
            set
            {
                if (_status == Status.DONE && value != Status.DONE) 
                    throw new InvalidOperationException("item is done");
                _status = value;
                _lastUpdated = DateTime.Now;
            }
        }

        public Bid(int amount, Status status = Status.TO_DO, string userName = null)
        {
            Amount = amount;
            _lastUpdated = DateTime.Now;
            _status = status;
            UserName = userName;
        }

        public Bid(int id, string descr, Status status = Status.TO_DO)
        {
            Id = id;
            //Description = descr;
            _lastUpdated = DateTime.Now;
            _status = status;
        }

        public Bid(int id, string descr, DateTime lastUpdated, Status status = Status.TO_DO)
        {
            Id = id;
            //Description = descr;
            _lastUpdated = lastUpdated;
            _status = status;
        }

        public Bid() { }

        public override string ToString()
        {
            return $"{Id}: {Amount} - {Status}";
        }
    }
}
