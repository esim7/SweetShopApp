using Domain.Model;

namespace WebApp.Models
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public double Quantity { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
    }
}