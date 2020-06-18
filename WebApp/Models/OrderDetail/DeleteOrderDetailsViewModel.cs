using WebApp.Models.Order;
using WebApp.Models.Product;

namespace WebApp.Models.OrderDetail
{
    public class DeleteOrderDetailsViewModel
    {
        public ProductViewModel Product { get; set; }
        public double Quantity { get; set; }
        public OrderViewModel Order { get; set; }
    }
}