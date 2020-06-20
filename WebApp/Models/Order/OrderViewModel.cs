using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Customer;
using WebApp.Models.OrderDetail;

namespace WebApp.Models.Order
{
    public class OrderViewModel
    {
        [Display(Name = "Идентификатор заказа")]
        public int Id { get; set; }
        [Display(Name = "Идентификатор покупателя")]
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        [Display(Name = "Итоговая стоимость")]
        public decimal TotalPrice { get; set; }
        public List<OrderDetailsViewModel> OrderDetails { get; set; } = new List<OrderDetailsViewModel>();
    }
}