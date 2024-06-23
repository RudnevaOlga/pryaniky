using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(string name, decimal price)
        {
            if (name != null && price > 0) 
            {
                var product = new Product
                {
                    name = name,
                    price = price
                };

                await _repository.AddAsync(product);
            }
        }

        public async Task DeleteAsync(int id)
        {
           var product = await GetByIdAsync(id);

            await _repository.DeleteAsync(product);
           
        }

        public async Task<List<Product>> GetAsync()
        {
            var result = await _repository.GetAsync();
            {
                if (result != null)
                {
                    return result;
                }

                throw new Exception("The products is out of stock");
            }
        }

        private async Task<Product> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product != null)
            {
                return product;
            }

            throw new Exception("The products is out of stock");
        }
    }
}
