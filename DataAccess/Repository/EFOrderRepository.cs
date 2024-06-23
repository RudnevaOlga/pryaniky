using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(List<OrderProduct> orderProduct)
        {
            await _context.ordersProduct.AddRangeAsync(orderProduct);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            _context.order.Remove(order);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAsync()
        {
            return await _context.order.ToListAsync();
        }

        public async Task<int> AddAsync(Order order)
        {
            await _context.order.AddAsync(order);

            await _context.SaveChangesAsync();

            return order.id;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.order.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
