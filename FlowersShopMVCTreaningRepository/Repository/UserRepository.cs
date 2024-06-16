using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTrainingRepository;
using Microsoft.EntityFrameworkCore;

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
        public bool ExistName(string login)
             => _dbSet.Any(x => x.UserName == login);
        public bool ExistPhone(string phone)
             => _dbSet.Any(x => x.Phone == phone);
    }
}
