using System.ComponentModel.DataAnnotations;
using WebApp.Models.Customer;

namespace WebApp.Models.Order
{
    public class DeleteOrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Идентификатор покупателя")]
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        [Display(Name = "Итоговая цена")]
        public decimal TotalPrice { get; set; }
    }
}