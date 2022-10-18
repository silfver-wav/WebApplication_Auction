namespace WebApplication_Auction.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public Bid(int amount)
        {
            Amount = amount;
            Date = DateTime.Now;
        }
        public Bid(int id, int amount)
        {
            Id = id;
            Amount = amount;
            Date = DateTime.Now;
        }
        public Bid() { }

        public override string ToString()
        {
            return $"{Id} {Amount} {Date}";
        }
    }
}
