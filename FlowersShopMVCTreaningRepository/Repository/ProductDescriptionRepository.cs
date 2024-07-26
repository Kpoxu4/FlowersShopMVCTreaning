using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTrainingRepository;


namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription>, IProductDescriptionRepository
    {
        public ProductDescriptionRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public void ChengeText(int descriptionId, string text)
        {
            var productDescription = _dbSet.FirstOrDefault(x => x.Id == descriptionId);
            productDescription.Text = text;
            _dbContext.SaveChanges();
        }

    }
}
