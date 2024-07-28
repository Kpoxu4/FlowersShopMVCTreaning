using FlowersShopMVCTraining.Mapper;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers
{
    public class CatalogController : Controller
    {
        private IShopCardRepository _shopCardRepository;
        private IShopCardMapper _shopCardMapper;
        private IImageHelper _imageHelper;
        public CatalogController(IShopCardRepository shopCardRepository, IShopCardMapper shopCardMapper, IImageHelper imageHelper)
        {
            _shopCardRepository = shopCardRepository;
            _shopCardMapper = shopCardMapper;
            _imageHelper = imageHelper;
        }
        [HttpGet]
        public IActionResult Catalog(string catalogName)
        {
            var model = new CatalogViewModel(); 
            var shopCardsDb = _shopCardRepository.GetCatalogItem(catalogName);             
            model.CatalogCards = _shopCardMapper.CreatedViewModelCard(shopCardsDb); 
            model.CardImages = _imageHelper.GetPathImages(shopCardsDb);
            model.CatalogName = catalogName;

            return View(model);
        }
   
    }
}
