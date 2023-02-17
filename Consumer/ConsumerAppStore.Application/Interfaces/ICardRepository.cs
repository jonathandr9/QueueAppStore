using ConsumerAppStore.Application.Models;

namespace ConsumerAppStore.Application.Interfaces
{
    public interface ICardRepository
    {
        Task Add(Card card);
    }
}
