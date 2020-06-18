namespace WebApp.Models.OrderDetail
{
    public class EditOrderDetailsViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public int OrderId { get; set; }
    }
}