using FlowersShopMVCTraining.Models.Enum;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;

namespace FlowersShopMVCTraining.Mapper
{
    public class ShopCardMapper : IShopCardMapper
    {
        private IShopCardRepository _shopCardRepository;

        public ShopCardMapper(IShopCardRepository shopCardRepository)
        {
            _shopCardRepository = shopCardRepository;
        }


        public ShopCardViewModel CreateShopCardViewModel(ShopCard shopCardBd)
        {
            var shopCard = new ShopCardViewModel
            {
                Id = shopCardBd.Id,
                Name = shopCardBd.Name,
                Catalog = (ShopCatalog)Enum.Parse(typeof(ShopCatalog), shopCardBd.Catalog),
                Price = shopCardBd.Price,
                Discount = shopCardBd.Discount
            };

            shopCard.Description = _shopCardRepository.GetDescriptionForProduct(shopCardBd.Id);

            shopCard.IsBestseller = (shopCardBd.Features & ProductFeatures.Bestseller) != 0 ? true : false;
            shopCard.IsDealOfDay = (shopCardBd.Features & ProductFeatures.DealOfDay) != 0 ? true : false;
            shopCard.IsNewArrival = (shopCardBd.Features & ProductFeatures.NewArrival) != 0 ? true : false;
            return shopCard;
        }

        public ShopCard UpddateShopCard(ShopCardViewModel card)
        {
            return new ShopCard
            {
                Id = card.Id,
                Name = card.Name,
                Catalog = Enum.GetName(card.Catalog).ToString(),
                ImageName = Enum.GetName(card.Catalog).ToString(),
                Price = card.Price,
                Discount = card.Discount,
                Features = GetFeatures(card.IsBestseller, card.IsDealOfDay, card.IsNewArrival),
            };
        }

        public ShopCard CreateShopCard(CreatingShopCardViewModel model, ProductDescription productDescription)
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

        public List<ShopCardViewModel> CreatedSliderCard(List<ShopCard> shopCardBd)
        {
            var ListShopCardViewModel = new List<ShopCardViewModel>();
            foreach (ShopCard shopCard in shopCardBd)
            {
                ListShopCardViewModel.Add(CreateShopCardViewModel(shopCard));
            }

            return ListShopCardViewModel;
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

      
    }
}
