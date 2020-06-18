namespace WebApp.Models.OrderDetail
{
    public class CreateOrderDetailsViewModel
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int OrderId { get; set; }
    }
}