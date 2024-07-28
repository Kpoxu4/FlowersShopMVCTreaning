using FlowersShopMVCTraining.Mapper;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Apis.Interface;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers
{
    public class CatalogController : Controller
    {
        private IShopCardRepository _shopCardRepository;
        private IShopCardMapper _shopCardMapper;
        private IImageHelper _imageHelper;
        private IHttpApiJoke _httpApiJoke;
       
        public CatalogController(
            IShopCardRepository shopCardRepository, 
            IShopCardMapper shopCardMapper, 
            IImageHelper imageHelper, 
            IHttpApiJoke httpApiJoke)
        {
            _shopCardRepository = shopCardRepository;
            _shopCardMapper = shopCardMapper;
            _imageHelper = imageHelper;
            _httpApiJoke = httpApiJoke;            
        }
        [HttpGet]
        public async Task<IActionResult> CatalogAsync(string catalogName)        {
                    
            var model = new CatalogViewModel();
            var joke = await _httpApiJoke.GetRandomJokeAsync();
            var shopCardsDb = _shopCardRepository.GetCatalogItem(catalogName);             
            model.CatalogCards = _shopCardMapper.CreatedViewModelCard(shopCardsDb); 
            model.CardImages = _imageHelper.GetPathImages(shopCardsDb);
            model.CatalogName = catalogName;
            model.Joke = joke.Setup;

            return View(model);
        }
   
    }
}
