using System.Collections.Generic;
using WebApp.Models.Order;

namespace WebApp.Models.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}