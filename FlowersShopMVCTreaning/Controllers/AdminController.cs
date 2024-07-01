using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;

namespace FlowersShopMVCTraining.Controllers
{
    [Authorize]
    [IsAdmin]
    public class AdminController : Controller
    {
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
                var shopCard = CreateShopCardViewModel(item);
                model.ShopCards.Add(shopCard);
                model.ImageNames.Add(item.ImageName);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(CreatingShopCardViewModel model, ShopCardViewModel card)
        {
            card.IsNewArrival = Request.Form["isNewArrival"] == "on";
            card.IsBestseller = Request.Form["isBestseller"] == "on";
            card.IsDealOfDay = Request.Form["isDealOfDay"] == "on";

            model.ShopCard = card;

            var productDescription = CreateProductDescription(model.ShopCard.Description!);
            _productDescriptionRepository.Create(productDescription);

            var shopCard = CreateShopCard(model, productDescription);
            _shopCardRepository.Create(shopCard);

            shopCard.ImageName += shopCard.Id.ToString();
            _shopCardRepository.UpdateNameImage(shopCard);

            SaveImageToFolder(model.Photo, shopCard.ImageName);

            TempData["Message"] = "Букет успешно создан";

            Task.Delay(2000).Wait();

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult UpdateCard(int cardId)
        {
            var shopCardBd = _shopCardRepository.Get(cardId);   
            var shopCardModel = CreateShopCardViewModel(shopCardBd);

            return View(shopCardModel);
        }
        [HttpPost]
        public IActionResult UpdateCard(ShopCardViewModel card)
        {
            card.IsNewArrival = Request.Form["isNewArrival"] == "on";
            card.IsBestseller = Request.Form["isBestseller"] == "on";
            card.IsDealOfDay = Request.Form["isDealOfDay"] == "on";

            var discriptionId = _shopCardRepository.GetDescriptionId(card.Id);
            _productDescriptionRepository.ChengeText(discriptionId, card.Description);

            var ShopCardDb = UpddateShopCard(card);

            _shopCardRepository.Update(ShopCardDb);

            TempData["Message"] = "Букет успешно обновлен";

            return RedirectToAction("Index", "Admin");
        }

        private ShopCardViewModel CreateShopCardViewModel(ShopCard shopCardBd)
        {
            var shopCard = new ShopCardViewModel
            {
                Id = shopCardBd.Id,
                Name = shopCardBd.Name,
                Catalog = (ShopCatalog)Enum.Parse(typeof(ShopCatalog), shopCardBd.Catalog),
                Price = shopCardBd.Price,
                Discount = shopCardBd.Discount
            };

            shopCard.Description = _productDescriptionRepository.GetDescriptionForProduct(shopCardBd.Id);

            shopCard.IsBestseller = (shopCardBd.Features & ProductFeatures.Bestseller) != 0 ? true : false;
            shopCard.IsDealOfDay = (shopCardBd.Features & ProductFeatures.DealOfDay) != 0 ? true : false;
            shopCard.IsNewArrival = (shopCardBd.Features & ProductFeatures.NewArrival) != 0 ? true : false;
            return shopCard;
        }
        private ProductDescription CreateProductDescription(string description)
        {
            return new ProductDescription
            {
                Text = description
            };
        }
        private ProductFeatures GetFeatures(bool isBestseller, bool isDealOfDay, bool newArrival)
        {
            var features = ProductFeatures.None;

            if (isBestseller)
                features |= ProductFeatures.Bestseller;
            if (isDealOfDay)
                features |= ProductFeatures.DealOfDay;
            if (newArrival)
                features |= ProductFeatures.NewArrival;

            return features;
        }
        private ShopCard UpddateShopCard(ShopCardViewModel card)
        {
            return new ShopCard
            {
                Id = card.Id,
                Name = card.Name,                
                Catalog = Enum.GetName(card.Catalog).ToString(),
                Price = card.Price,
                Discount = card.Discount,
                Features = GetFeatures(card.IsBestseller, card.IsDealOfDay, card.IsNewArrival),
            };
        }
        private ShopCard CreateShopCard(CreatingShopCardViewModel model, ProductDescription productDescription)
        {
            return new ShopCard
            {
                Name = model.ShopCard.Name,
                ImageName = Enum.GetName(model.ShopCard.Catalog).ToString(),
                Catalog = Enum.GetName(model.ShopCard.Catalog).ToString(),
                Price = model.ShopCard.Price,
                Discount = model.ShopCard.Discount,
                Features = GetFeatures(model.ShopCard.IsBestseller, model.ShopCard.IsDealOfDay, model.ShopCard.IsNewArrival),
                ProductDescription = productDescription
            };
        }
        private void SaveImageToFolder(IFormFile file, string imageName)
        {
            string fileName = file.FileName;
            var extension = Path.GetExtension(fileName);
            var path = _pathHelper.GetPathByFolder("img\\watch", imageName + extension);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }
        }
    }

}
