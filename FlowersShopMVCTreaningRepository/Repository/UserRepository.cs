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
        public bool FiledValueExists(string fieldName, string fieldValue) //todo refactoring
        {
            bool exists = _dbContext.Set<User>().Any(u => EF.Property<string>(u, fieldName) == fieldValue);
            return exists;
        }
    }
}
