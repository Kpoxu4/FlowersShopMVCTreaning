using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class ProductDescriptionRepository : BaseRepository<ProductDescription>
    {
        public ProductDescriptionRepository(FlowersShopDbContext dbContext) : base(dbContext) { }
    }
}
