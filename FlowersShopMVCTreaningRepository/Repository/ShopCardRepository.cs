using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTrainingRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ShopCardRepository : BaseRepository<ShopCard>, IShopCardRepository
    {
        public ShopCardRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public void Update(ShopCard shopCard)
        {
            var dbshopCard = Get(shopCard.Id);

            if (shopCard.Name != null)
            {
                dbshopCard.Name = shopCard.Name;
            }
            if (shopCard.Catalog != null)
            {
                dbshopCard.Catalog = shopCard.Catalog;
            }
            if (dbshopCard.ImageName != null)
            {
                dbshopCard.ImageName = shopCard.ImageName;
            }
            if (shopCard.Price != 0)
            {
                dbshopCard.Price = shopCard.Price;
            }
            if (shopCard.Discount != null)
            {
                dbshopCard.Discount = shopCard.Discount;
            }
            dbshopCard.Features = shopCard.Features;

            _dbContext.SaveChanges();
        }
        public void UpdateNameImage(ShopCard shopCard)
        {
            var dbshopCard = Get(shopCard.Id);

            dbshopCard.ImageName = shopCard.ImageName;

            _dbContext.SaveChanges();
        }
        public int GetDescriptionId(int shopCardId)
        {
            var descriptionId = _dbSet
                            .Include(x => x.ProductDescription)
                            .FirstOrDefault(x => x.Id == shopCardId).ProductDescription.Id;
            return descriptionId;
        }
        public string GetImageName(int shopCardId)
        {
            return Get(shopCardId)!.ImageName;
        }
        public string GetDescriptionForProduct(int shopCardBdId)
        {

            var description = _dbSet
                             .Include(x => x.ProductDescription)
                             .FirstOrDefault(x => x.Id == shopCardBdId).ProductDescription.Text;

            return description;
        }
    }
}
