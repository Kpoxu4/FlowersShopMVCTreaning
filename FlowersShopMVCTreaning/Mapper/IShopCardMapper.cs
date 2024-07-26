using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Mapper
{
    public interface IShopCardMapper
    {
        ShopCard CreateShopCard(CreatingShopCardViewModel model, ProductDescription productDescription);
        ShopCardViewModel CreateShopCardViewModel(ShopCard shopCardBd);
        ShopCard UpddateShopCard(ShopCardViewModel card);
    }
}