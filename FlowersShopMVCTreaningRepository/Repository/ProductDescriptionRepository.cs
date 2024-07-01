using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription>
    {
        public ProductDescriptionRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public string GetDescriptionForProduct(int descriptionId)
        {
            var result = _dbSet.FirstOrDefault(x => x.Id == descriptionId);
            return result.Text;
        }
        public void ChengeText(int descriptionId, string text)
        {
            var productDescription = _dbSet.FirstOrDefault(x => x.Id == descriptionId);
            productDescription.Text = text;
            _dbContext.SaveChanges();
        }

    }
}
