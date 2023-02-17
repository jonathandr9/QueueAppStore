namespace ConsumerAppStore.Application.Models
{
    public class Card
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime ValidThru { get; set; }
        public int CVC { get; set; }
    }

    public class Payment
    {
        public int OrderId { get; set; }
        public Card Card { get; set; }
        public int Amounts { get; set; }
        public double Value { get; set; }
        public int ClientId { get; set; }
    }
}
