using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Service.Interface
{
    public interface IImageHelper
    {
        void RenameImage(string newName, string oldName);
        void SaveImageToFolder(IFormFile file, string imageName);
        Dictionary<int, string> GetPathImages(List<ShopCard> shopCards);
    }
}
