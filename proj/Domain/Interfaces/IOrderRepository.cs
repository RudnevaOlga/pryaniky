using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task DeleteAsync(Order order);

        Task<List<Order>> GetAsync();

        Task SaveAsync(List<OrderProduct> orderProduct);

        Task<int> AddAsync(Order order);

        Task<Order> GetByIdAsync(int id);
    }
}