using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.OrderDetail
{
    public class CreateOrderDetailsViewModel
    {
        [Display(Name = "Идентификатор товара")]
        public int ProductId { get; set; }
        [Display(Name = "Количество")]
        public double Quantity { get; set; }
        [Display(Name = "Идентификатор заказа")]
        public int OrderId { get; set; }
    }
}