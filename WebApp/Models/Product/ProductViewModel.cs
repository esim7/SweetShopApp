using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Наименование товара")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}