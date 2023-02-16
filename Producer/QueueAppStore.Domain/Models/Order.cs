namespace QueueAppStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdApp { get; set; }
        public int PaymentStatus { get; set; }
        public int Amounts { get; set; }
        public decimal Value { get; set; }
        public int LastCardDigits { get; set; }


        public Card Card { get; set; }
        public Client Client { get; set; }
        public App App { get; set; }
    }
}
