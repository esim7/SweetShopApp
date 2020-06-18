using WebApp.Models.Customer;

namespace WebApp.Models.Order
{
    public class DeleteOrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}