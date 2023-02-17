using QueueAppStore.Domain.Adapters;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Application
{
    public sealed class ClientService : IClientService
    {
        private readonly IIdentityAdapter _identityAdapter;
        private readonly IClientRepository _clientRepository;


        public ClientService(IIdentityAdapter identityAdapter,
            IClientRepository clientRepository)
        {
            _identityAdapter = identityAdapter;
            _clientRepository = clientRepository;
        }

        public async Task<string> Login(User user)
        {
            return await _identityAdapter.Login(user);
        }

        public async Task<int> Register(
            Client client,
            User user)
        {
            var idIdentity = await _identityAdapter.RegisterUser(user);

            client.IdentityId = idIdentity;

            return await _clientRepository.Add(client);
            
        }
    }
}
