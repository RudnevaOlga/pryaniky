using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task DeleteAsync(Product product);

        Task<List<Product>> GetAsync();

        Task<Product> GetByIdAsync(int id);
    }
}
