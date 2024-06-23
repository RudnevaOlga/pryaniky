namespace Domain.Entities
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
