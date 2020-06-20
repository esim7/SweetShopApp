using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Order
{
    public class CreateOrderViewModel
    {
        [Display(Name = "Идентификатор покупателя")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Итоговая цена")]
        public decimal TotalPrice { get; set; }
    }
}