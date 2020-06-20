using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Order;

namespace WebApp.Models.Customer
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя покупателя")]
        public string Name { get; set; }
        [Display(Name = "Почтовый адресс")]
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }
}