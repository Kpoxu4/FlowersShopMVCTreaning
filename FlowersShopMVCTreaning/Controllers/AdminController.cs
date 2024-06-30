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
                var shopCard = new ShopCardViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Catalog = (ShopCatalog)Enum.Parse(typeof(ShopCatalog), item.Catalog),
                    Price = item.Price,
                    Discount = item.Discount
                };

                shopCard.Description = _productDescriptionRepository.GetDescriptionForProduct(item.Id);

                shopCard.IsBestseller = (item.Features & ProductFeatures.Bestseller) != 0 ? true : false;
                shopCard.IsDealOfDay = (item.Features & ProductFeatures.DealOfDay) != 0 ? true : false;
                shopCard.IsNewArrival = (item.Features & ProductFeatures.NewArrival) != 0 ? true : false;

                model.ShopCards.Add(shopCard);
                model.ImageNames.Add(item.ImageName);
            }
            var test = model;
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

            Task.Delay(1000).Wait();

            return RedirectToAction("Index", "Admin");
        }
        private ProductDescription CreateProductDescription(string description)
        {
            return new ProductDescription
            {
                Text = description
            };
        }
        private ProductFeatures GetFeatures(CreatingShopCardViewModel model)
        {
            var features = ProductFeatures.None;

            if (model.ShopCard.IsBestseller)
                features |= ProductFeatures.Bestseller;
            if (model.ShopCard.IsDealOfDay)
                features |= ProductFeatures.DealOfDay;
            if (model.ShopCard.IsNewArrival)
                features |= ProductFeatures.NewArrival;

            return features;
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
                Features = GetFeatures(model),
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
