using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Repository.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistName(string login);
        bool ExistPhone(string phone);
        User GetRegistrationUser(string userName);
    }
}