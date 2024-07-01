using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AdminController
    {
        private const string EXTENSION_IMAGE = ".jpg";
        private ProductDescriptionRepository _productDescriptionRepository;
        private ShopCardRepository _shopCardRepository;
        private PathHelper _pathHelper;

        public AdminController(ProductDescriptionRepository productDescriptionRepository, 
                               ShopCardRepository shopCardRepository,
                               PathHelper pathHelper)
        {
            _productDescriptionRepository = productDescriptionRepository;
            _shopCardRepository = shopCardRepository;
            _pathHelper = pathHelper;
        }
        public void DeleteCard(int cardId)
        {
            var imageName = _shopCardRepository.Get(cardId)!.ImageName + EXTENSION_IMAGE;
            var pathToSmall = _pathHelper.GetPathByFolder("img\\output\\small", imageName);
            var pathToLarge = _pathHelper.GetPathByFolder("img\\output\\large", imageName);
            var productDescriptionId = _shopCardRepository.GetDescriptionId(cardId);

            _productDescriptionRepository.Delete(productDescriptionId);
            _shopCardRepository.Delete(cardId);
            File.Delete(pathToSmall);
            File.Delete(pathToLarge);
        }
    }
}
