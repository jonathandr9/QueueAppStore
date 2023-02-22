namespace QueueAppStore.API.Models
{
    public class OrderGet
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdApp { get; set; }
        public string IdPaymentStatus { get; set; }
        public string PaymentStatus { get; set; }
        public int Amounts { get; set; }
        public decimal? Value { get; set; }
        public int LastCardDigits { get; set; }
    }
}
