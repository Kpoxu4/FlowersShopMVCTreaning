using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class UserRepository :BaseRepository<User>
    {
        public UserRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public User GetRegistrationUser(string userName, string password)
        {
            var user = _dbSet.FirstOrDefault(user => user.UserName == userName && user.Password == password);
            return user;
        }
    }
}
