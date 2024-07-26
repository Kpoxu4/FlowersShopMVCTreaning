
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        private const string EXTENSION_IMAGE = ".jpg";
        private IProductDescriptionRepository _productDescriptionRepository;
        private IShopCardRepository _shopCardRepository;
        private PathHelper _pathHelper;
        private ILogger<AdminController> _logger;

        public AdminController(IProductDescriptionRepository productDescriptionRepository, 
                               IShopCardRepository shopCardRepository,
                               PathHelper pathHelper,
                               ILogger<AdminController> logger)
        {
            _productDescriptionRepository = productDescriptionRepository;
            _shopCardRepository = shopCardRepository;
            _pathHelper = pathHelper;
            _logger = logger;
        }
        public IActionResult DeleteCard(int cardId)
        {
            var shopCard = _shopCardRepository.Get(cardId);

            if(shopCard == null)
            {
                _logger.LogError($"Удаление завершилось с ошибкой. Запрошенный в базе не существует {cardId}");
                return BadRequest();
            }

            var imageName = shopCard.ImageName + EXTENSION_IMAGE;           
            var pathToSmall = _pathHelper.GetPathByFolder("img\\output\\small", imageName);
            var pathToLarge = _pathHelper.GetPathByFolder("img\\output\\large", imageName);
            var productDescriptionId = _shopCardRepository.GetDescriptionId(cardId);

            _productDescriptionRepository.Delete(productDescriptionId);
            _shopCardRepository.Delete(cardId);
            System.IO.File.Delete(pathToSmall);
            System.IO.File.Delete(pathToLarge);

            return Ok();
        }
    }
}
