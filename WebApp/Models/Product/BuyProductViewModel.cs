using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Product
{
    public class BuyProductViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Наименование товара")]
        public string Title { get; set; }
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }
        [Display(Name = "Количество")]
        public int? Quantity { get; set; }
    }
}