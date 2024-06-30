using FlowersShopMVCTraining.Repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AdminController
    {
        private ProductDescriptionRepository _productDescriptionRepository;
        private ShopCardRepository _shopCardRepository;

        public AdminController(ProductDescriptionRepository productDescriptionRepository, ShopCardRepository shopCardRepository)
        {
            _productDescriptionRepository = productDescriptionRepository;
            _shopCardRepository = shopCardRepository;
        }
        public void DeleteCard(int cardId)
        {
            _shopCardRepository.Delete(cardId);
        }
    }
}
