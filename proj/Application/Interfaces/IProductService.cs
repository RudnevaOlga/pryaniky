using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(string name, decimal price);

        Task DeleteAsync(int id);

        Task<List<Product>> GetAsync();
    }
}
