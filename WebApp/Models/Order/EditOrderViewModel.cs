using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Order
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Идентификатор покупателя")]
        public int CustomerId { get; set; }
        [Display(Name = "Итоговая цена")]
        public decimal TotalPrice { get; set; }
    }
}