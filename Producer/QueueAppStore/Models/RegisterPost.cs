namespace QueueAppStore.API.Models
{
    public class RegisterPost
    {
        public string Name { get; set; }
        public int Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }
}
