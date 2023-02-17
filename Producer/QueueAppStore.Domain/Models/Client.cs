namespace QueueAppStore.Domain.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string  Sex { get; set; }
        public string Address { get; set; }
        public Guid IdentityId { get; set; }
    }
}
