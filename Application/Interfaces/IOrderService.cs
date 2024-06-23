using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderService
    {
        Task DeleteAsync(int id);

        Task<List<Order>> GetAsync();

        Task SaveAsync(List<int> productIds);

    }
}