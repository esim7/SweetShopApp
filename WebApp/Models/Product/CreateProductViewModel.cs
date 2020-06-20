using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Product
{
    public class CreateProductViewModel
    {
        [Display(Name = "Наименование товара")]
        public string Title { get; set; }
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }
    }
}