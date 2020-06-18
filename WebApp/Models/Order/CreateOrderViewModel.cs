using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Order
{
    public class CreateOrderViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}