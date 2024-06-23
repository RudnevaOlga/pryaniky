using Newtonsoft.Json;

namespace Pryaniky.LocalStorage
{
    public class LocalStorageProduct : ILocalStorageProduct
    {
        private const string Product = "Product";
        private readonly IHttpContextAccessor _httpContext;

        public LocalStorageProduct(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void SetProduct(int id)
        {
            var basket = _httpContext.HttpContext.Session.GetObjectFromJson<List<int>>(Product) ?? new List<int>();

            basket.Add(id);
            _httpContext.HttpContext.Session.SetObjectAsJson(Product, basket);
        }

        public void RemoveStorage()
        {
            _httpContext.HttpContext.Session.Remove(Product);
        }

        public List<int> GetProducts() => _httpContext.HttpContext.Session.GetObjectFromJson<List<int>>(Product);
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
