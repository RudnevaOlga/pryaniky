namespace Domain.Entities
{
    public class OrderProduct
    {
        public int id { get; set; }

        public int orderId { get; set; }

        public int productId { get; set; }

        public Order order { get; set; }

        public Product product { get; set; }
    }
}
