namespace WebApp.Models.Order
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}