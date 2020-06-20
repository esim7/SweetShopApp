using System.ComponentModel.DataAnnotations;
using WebApp.Models.Order;
using WebApp.Models.Product;

namespace WebApp.Models.OrderDetail
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Идентификатор продукта")]
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        [Display(Name = "Количество")]
        public double Quantity { get; set; }
        [Display(Name = "Идентификатор заказа")]
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
    }
}