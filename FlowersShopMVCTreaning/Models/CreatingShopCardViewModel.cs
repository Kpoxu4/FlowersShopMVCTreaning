using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models
{
    public class CreatingShopCardViewModel
    {
        [Required(ErrorMessage = "Фото надо-бы загрузить.")]
        [FileExtension(".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg")]
        public IFormFile Photo { get; set; }
        public ShopCardViewModel ShopCard { get; set; }
    }
}
