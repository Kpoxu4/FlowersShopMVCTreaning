using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription>
    {
        public ProductDescriptionRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public string  GetDescriptionForProduct(int productId)
        {
            var result = _dbSet.FirstOrDefault(x => x.Id == productId);
            return result.Text;
        }
    }
}
