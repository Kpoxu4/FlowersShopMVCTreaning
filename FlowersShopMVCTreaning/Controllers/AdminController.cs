﻿using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreatingShopCardViewModel model)
        {
            var productDescription = CreateProductDescription(model.ShopCard.Description!);
            _productDescriptionRepository.Create(productDescription);

            var shopCard = CreateShopCard(model, productDescription);
            _shopCardRepository.Create(shopCard);

            shopCard.ImageName += shopCard.Id.ToString();
            _shopCardRepository.UpdateNameImage(shopCard);

            string fileName = model.Photo.FileName;
            var extension = Path.GetExtension(fileName);
            var path = _pathHelper.GetPathByFolder("img\\watch", shopCard.ImageName + extension);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                model.Photo.CopyTo(fs);
            }            

            return View();
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
    }

}
