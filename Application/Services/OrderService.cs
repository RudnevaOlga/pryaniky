using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveAsync(List<int> productIds)
        {
            if (productIds != null) 
            {
                var orderProducts = new List<OrderProduct>();

                var orderId = await AddOrderAsync();

                foreach (var productId in productIds)
                {
                    var orderProduct = new OrderProduct
                    {
                        productId = productId,
                        orderId = orderId
                    };

                    orderProducts.Add(orderProduct);
                }

                await _repository.SaveAsync(orderProducts);

                return;
            }
            
            throw new Exception("The product is out of stock");
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);

            await _repository.DeleteAsync(order);
        }

        public async Task<List<Order>> GetAsync()
        {
            var result = await _repository.GetAsync();

            if (result != null)
            {
                return result;
            }

            throw new Exception("The orders is missing");
        }

        private async Task<int> AddOrderAsync()
        {
            var order = new Order
            {
                orderDate = DateTime.UtcNow,
            };

            return await _repository.AddAsync(order);
        }

        private async Task<Order> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order != null)
            {
                return order;
            }

            throw new Exception("The order is missing");
        }
    }
}
