using Application.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Pryaniky.LocalStorage;
using System.ComponentModel;

namespace Pryaniky.Controllers
{
    [Route("/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILocalStorageProduct _localStorageProduct;

        public OrderController(IOrderService orderService, ILocalStorageProduct localStorageProduct)
        {
            _orderService = orderService;
            _localStorageProduct = localStorageProduct;
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost(nameof(AddToBasket))]
        public string AddToBasket([FromBody] int productId)
        {
            _localStorageProduct.SetProduct(productId);

            return OperationStatus.Add.GetDisplayName();
        }

        /// <summary>
        /// Оформить заказ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(CheckOut))]
        public async Task<IActionResult> CheckOut()
        {
            var products = _localStorageProduct.GetProducts();

            await _orderService.SaveAsync(products);

            _localStorageProduct.RemoveStorage();

            return Ok();
        }

        /// <summary>
        /// Удалить заказ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(nameof(Delete))]
        public async Task<string> Delete([FromQuery] int id)
        {
            await _orderService.DeleteAsync(id);

            return OperationStatus.Deleted.GetDisplayName();
        }

        /// <summary>
        /// Получить список заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(Get))]
        public async Task<List<Order>> Get()
        {
            return await _orderService.GetAsync();
        }
    }
}
