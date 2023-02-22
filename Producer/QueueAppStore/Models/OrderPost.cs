namespace QueueAppStore.API.Models
{
    public class OrderPost
    {
        public int IdCLient { get; set; }
        public int IdApp { get; set; }
        public int Amounts { get; set; }
        public CardOrderPost Card { get; set; }
    }

    public class CardOrderPost
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string ValidThru { get; set; }
        public int CVC { get; set; }
    }
}
