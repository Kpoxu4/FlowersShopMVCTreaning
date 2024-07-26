using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;

namespace FlowersShopMVCTraining.Service.Interface
{
    public interface IAuthService
    {
        User GetUser();
        int GetUserId();
        string GetUserName();
        UserRole GetUserRole();
        bool IsAdmin();
        bool IsAuthenticated();
    }
}