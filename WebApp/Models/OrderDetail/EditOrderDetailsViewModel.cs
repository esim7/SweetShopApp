using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.OrderDetail
{
    public class EditOrderDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Идентификатор продукта")]
        public int ProductId { get; set; }
        [Display(Name = "Количество")]
        public double Quantity { get; set; }
        [Display(Name = "Идентификатор заказа")]
        public int OrderId { get; set; }
    }
}