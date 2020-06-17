using System.Collections.Generic;
using Domain.Model;

namespace WebApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetailsViewModel> OrderDetails { get; set; } = new List<OrderDetailsViewModel>();
    }
}