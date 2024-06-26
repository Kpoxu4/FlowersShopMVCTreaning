﻿using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ShopCardRepository : BaseRepository<ShopCard>
    {
        public ShopCardRepository(FlowersShopDbContext dbContext) : base(dbContext) { }


        public string Name { get; set; }
       
        public string Catalog { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public ProductFeatures Features { get; set; }
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
            if (shopCard.Price != 0)
            {
                dbshopCard.Price = shopCard.Price;
            }
            if(shopCard.Discount != 0)
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

    }
}
