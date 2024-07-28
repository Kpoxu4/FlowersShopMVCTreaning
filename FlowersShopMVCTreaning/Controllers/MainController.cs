using FlowersShopMVCTraining.Mapper;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowersShopMVCTraining.Controllers
{
    public class MainController : Controller
    {
        private IShopCardRepository _shopCardRepository;
        private IShopCardMapper _shopCardMapper;
        private IImageHelper _imageHelper;
        public MainController(IShopCardRepository shopCardRepository, IShopCardMapper shopCardMapper, IImageHelper imageHelper)
        {
            _shopCardRepository = shopCardRepository;
            _shopCardMapper = shopCardMapper;
            _imageHelper = imageHelper;
        }
        public IActionResult Index(MainIndexViewModel model)
        {
            var shopCardDb = _shopCardRepository.GetSliderItem();
            model.SliderCards = _shopCardMapper.CreatedSliderCard(shopCardDb);
            model.CardImages = _imageHelper.GetPathImages(shopCardDb);         


            return View(model);
        }
    }
}
