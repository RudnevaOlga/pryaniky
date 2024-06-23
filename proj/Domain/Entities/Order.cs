namespace Domain.Entities
{
    public class Order
    {
        public int id { get; set; }

        public DateTime orderDate { get; set; }

        public ICollection<OrderProduct> orderProducts { get; set; }
    }
}
