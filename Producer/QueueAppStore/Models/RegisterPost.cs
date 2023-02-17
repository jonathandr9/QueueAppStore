namespace QueueAppStore.API.Models
{
    public class RegisterPost
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
