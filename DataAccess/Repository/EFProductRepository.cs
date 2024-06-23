using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.product.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.product.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _context.product.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.product.FirstOrDefaultAsync(x => x.id == id);
        }
    }
}
