using FlowersShopMVCTraining.Repository.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Repository.Model
{
    public class ShopCard : BaseModel
    {
        public string Name { get; set; }
        public string ImageName { get; set; }
        public Catalog Catalog { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public ProductFeatures Features { get; set; }
        public virtual ProductDescription? ProductDescription { get; set; }
    }
}
