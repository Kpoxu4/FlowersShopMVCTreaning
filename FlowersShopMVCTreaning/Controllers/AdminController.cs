using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using FlowersShopMVCTraining.Mapper;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;

namespace FlowersShopMVCTraining.Controllers
{
    [Authorize]
    [IsAdmin]
    public class AdminController : Controller
    {
        private IProductDescriptionRepository _productDescriptionRepository;
        private IShopCardRepository _shopCardRepository;
        private IPathHelper _pathHelper;
        private IImageHelper _imageHelper;
        private IShopCardMapper _shopCardMapper;

        public AdminController(IProductDescriptionRepository productDescriptionRepository,
                                                   IShopCardRepository shopCardRepository,
                                                                    IPathHelper pathHelper,
                                                                    IImageHelper imageHelper,
                                                                    IShopCardMapper shopCardMapper)
        {
            _productDescriptionRepository = productDescriptionRepository;
            _shopCardRepository = shopCardRepository;
            _pathHelper = pathHelper;
            _imageHelper = imageHelper;
            _shopCardMapper = shopCardMapper;
        }

        [HttpGet]
        public IActionResult Index(ShowAdminShopCardViewModel model)
        {
            if (TempData["Message"] is not null)
            {
                model.MessageCreationCard = TempData["Message"]?.ToString();
                TempData.Remove("Message");
            }
            var allCards = _shopCardRepository.GetAll();

            if (allCards.Count == 0 && allCards == null)
            {
                return View(model);
            }

            model.ShopCards = new List<ShopCardViewModel>();
            model.ImageNames = new List<string>();

            foreach (ShopCard item in allCards)
            {
                var shopCard = _shopCardMapper.CreateShopCardViewModel(item);
                model.ShopCards.Add(shopCard);
                model.ImageNames.Add(item.ImageName);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(CreatingShopCardViewModel model, ShopCardViewModel card)
        {
            if (!ModelState.IsValid)
            {
                var firstError = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).First();
                TempData["Message"] = $"Букет не создан: {firstError}";
                return RedirectToAction("Index", "Admin");
            }

            model.ShopCard = card;

            var productDescription = CreateProductDescription(model.ShopCard.Description!);
            _productDescriptionRepository.Create(productDescription);

            var shopCard = _shopCardMapper.CreateShopCard(model, productDescription);
            _shopCardRepository.Create(shopCard);

            shopCard.ImageName += shopCard.Id.ToString();
            _shopCardRepository.UpdateNameImage(shopCard);

            _imageHelper.SaveImageToFolder(model.Photo, shopCard.ImageName);

            TempData["Message"] = "Букет успешно создан";

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateCard(int cardId)
        {
            var shopCardBd = _shopCardRepository.Get(cardId);
            var shopCardModel = _shopCardMapper.CreateShopCardViewModel(shopCardBd);

            return View(shopCardModel);
        }
        [HttpPost]
        public IActionResult UpdateCard(ShopCardViewModel card)
        {
            var discriptionId = _shopCardRepository.GetDescriptionId(card.Id);
            _productDescriptionRepository.ChengeText(discriptionId, card.Description);

            var imageName = _shopCardRepository.GetImageName(card.Id);

            var ShopCardDb = _shopCardMapper.UpddateShopCard(card);
            ShopCardDb.ImageName += ShopCardDb.Id.ToString();

            _shopCardRepository.Update(ShopCardDb);

            var newNameFile = ShopCardDb.ImageName;

            if (!string.Equals(imageName, newNameFile))
            {
                _imageHelper.RenameImage(newNameFile, imageName);
            }

            TempData["Message"] = "Букет успешно обновлен";

            return RedirectToAction("Index", "Admin");
        }      

        private ProductDescription CreateProductDescription(string description)
        {
            return new ProductDescription
            {
                Text = description
            };
        }        
    }
}
