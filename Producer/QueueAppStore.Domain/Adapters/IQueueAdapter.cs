﻿using QueueAppStore.Domain.Models;

namespace QueueAppStore.Domain.Adapters
{
    public interface IQueueAdapter
    {
        Task AddPaymentMessage(Payment payment);
    }
}
