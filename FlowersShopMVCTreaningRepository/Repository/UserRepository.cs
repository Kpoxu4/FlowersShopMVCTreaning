using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class UserRepository :BaseRepository<User>
    {
        public UserRepository(FlowersShopDbContext dbContext) : base(dbContext) { }
    }
}
