using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Repository.Repository.Interface
{
    public interface IProductDescriptionRepository : IBaseRepository<ProductDescription>
    {
        void ChengeText(int descriptionId, string text);
    }
}