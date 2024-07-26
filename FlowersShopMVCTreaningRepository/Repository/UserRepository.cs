using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTrainingRepository;
using Microsoft.EntityFrameworkCore;

namespace FlowersShopMVCTraining.Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FlowersShopDbContext dbContext) : base(dbContext) { }

        public User GetRegistrationUser(string userName)
        {
            var user = _dbSet.FirstOrDefault(user => user.UserName == userName);
            return user;
        }
        public bool ExistName(string login)
             => _dbSet.Any(x => x.UserName == login);
        public bool ExistPhone(string phone)
             => _dbSet.Any(x => x.Phone == phone);
    }
}
