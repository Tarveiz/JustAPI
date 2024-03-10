using JustAPI.Enums;

namespace JustAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> ProductList { get; set; } = new List<Product>();
        public DateTime OrderDate { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public decimal OrderCost { get; set; }
        public Currency Currency { get; set; }
    }
}
