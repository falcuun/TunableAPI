namespace TunableInterview.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
