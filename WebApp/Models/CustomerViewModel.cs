using System.Collections.Generic;
using Domain.Model;

namespace WebApp.Models
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