using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models
{
    public class ShopCardViewModel
    {
        private const string ERROR_PRICE = "Цена должна быть положительным числом.";
        private const string ERROR_DISCOUNT = "Цена должна быть числом от 0 до 50.";
                
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя не должно быть пустым.")]
        [StringLength(19, MinimumLength = 3, ErrorMessage = "Название должны быть от 3 до 19 символов включая пробелы")]
        public string Name { get; set; }
        public ShopCatalog Catalog { get; set; }
        [Required(ErrorMessage = "Описание не должно быть пустым.")]
        [StringLength(226, MinimumLength = 20, ErrorMessage = "Описание должны быть от 20 до 226 символов включая пробелы")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Цена не должна быть пустым полем.")]
        [Range(0, double.MaxValue, ErrorMessage = ERROR_PRICE)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = ERROR_PRICE)]
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; } 
        public bool IsNewArrival { get; set; } 
        public bool IsDealOfDay { get; set; } 

        [Range(0, 50, ErrorMessage = ERROR_DISCOUNT)]
        [RegularExpression(@"^\d+$", ErrorMessage = ERROR_DISCOUNT)]
        public int? Discount { get; set; }
    }
}
