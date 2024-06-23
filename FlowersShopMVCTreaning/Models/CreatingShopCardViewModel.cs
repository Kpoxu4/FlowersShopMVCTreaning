using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models
{
    public class CreatingShopCardViewModel
    {
        private const string ERROR_PRICE = "Цена должна быть положительным числом.";
        private const string ERROR_DISCOUNT = "Цена должна быть числом от 0 до 50.";

        [Required]
        [FileExtension(".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg")]
        public IFormFile Photo { get; set; }
        [Required]
        [StringLength(19, MinimumLength = 3, ErrorMessage = "Название должны быть от 3 до 19 символов включая пробелы")]
        public string name { get; set; }
        public ShopCatalog Catalog { get; set; }
        [Required]
        [StringLength(226, MinimumLength = 20, ErrorMessage = "Описание должны быть от 20 до 226 символов включая пробелы")]
        public string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = ERROR_PRICE)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = ERROR_PRICE)]
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsNewArrival { get; set; }
        public bool IsDealOfDay { get; set; }
        [Required]
        [Range(0, 50, ErrorMessage = ERROR_DISCOUNT)]
        [RegularExpression(@"^\d+$", ErrorMessage = ERROR_DISCOUNT)]
        public int Discount { get; set; }
    }
}
