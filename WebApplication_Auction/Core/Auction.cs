using System.Reflection;

namespace WebApplication_Auction.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartingBid { get; set; }

        private List<Bid> _bids = new List<Bid>();

        public IEnumerable<Bid> Bids => _bids;

        public DateTime StartingDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Auction(string name, string desc, int price, DateTime expDate)
        {
            Name = name;
            Description = desc;
            StartingBid = price;
            StartingDate = DateTime.Now;
            ExpirationDate = expDate;
        }

        public Auction(int id, string name, string desc, int price, DateTime expDate)
        {
            Id = id;
            Name = name;
            Description = desc;
            StartingBid = price;
            StartingDate = DateTime.Now;
            ExpirationDate = expDate;
        }
        public Auction() { }

        public void AddBid(Bid newBid)
        {
            if(newBid.Amount > FindHighestBid())
            {
                _bids.Add(newBid);
            }
        }
        
        private int FindHighestBid()
        {
            if(_bids.Count == 0)
            {
                return 0;
            }
            return _bids.Max(t => t.Amount);
            
        }
        
        public override string ToString()
        {
            return $"{Id} {Name} {Description} {StartingBid}";
        }
    }
}
