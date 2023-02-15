namespace QueueAppStore.Domain.Models
{
    public class Card
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime ValidThru { get; set; }
        public int CVC { get; set; }
    }
}
