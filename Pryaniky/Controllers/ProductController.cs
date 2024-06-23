using Application.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace Pryaniky.Controllers
{
    [Route("/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Добавить продукт
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<string> Add([FromBody]string name, [FromBody]decimal price)
        {
            await _productService.AddAsync(name, price);

            return OperationStatus.Add.GetDisplayName();
        }

        /// <summary>
        /// Удалить продукт
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete(nameof(Delete))]
        public async Task<string> Delete([FromQuery]int id)
        {
            await _productService.DeleteAsync(id);

            return OperationStatus.Deleted.GetDisplayName();
        }

        /// <summary>
        /// Получить список продуктов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(Get))]
        public async Task<List<Product>> Get()
        {
            return await _productService.GetAsync();
        }
    }
}
