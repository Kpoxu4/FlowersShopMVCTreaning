using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Repository.Repository.Interface
{
    public interface IShopCardRepository : IBaseRepository<ShopCard>
    {
        string GetDescriptionForProduct(int shopCardBdId);
        int GetDescriptionId(int shopCardId);
        string GetImageName(int shopCardId);
        void Update(ShopCard shopCard);
        void UpdateNameImage(ShopCard shopCard);
        List<ShopCard> GetSliderItem();
        List<ShopCard> GetCatalogItem(string catalogName);
    }
}