using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Customer
{
    public class CreateCustomerViewModel
    {
        [Display(Name = "Имя покупателя")]
        public string Name { get; set; }
        [Display(Name = "Почтовый адресс")]
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
    }
}