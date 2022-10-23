namespace ProjectApp.Core
{
    public class Bid
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }


        public Bid(int id, int amount)
        {
            Id = id;
            Amount = amount;
        }

        public Bid(int id, int amount, DateTime date)
        {
            Id = id;
            Amount = amount;
            Date = date;
        }

        public Bid() { }

        public override string ToString()
        {
            return $"{Id}: {Amount} - {Date}";
        }
    }
}
