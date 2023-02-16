﻿using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IClientRepository
    {
        Task<Client> GetClient();
    }
}
