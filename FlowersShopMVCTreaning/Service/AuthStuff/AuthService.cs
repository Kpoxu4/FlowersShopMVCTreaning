using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using System.Security;

namespace FlowersShopMVCTraining.Service.AuthStuff
{
    public class AuthService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private UserRepository _userRepository;

        public AuthService(IHttpContextAccessor httpContextAccessor, UserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public bool IsAuthenticated()
            => _httpContextAccessor.HttpContext!.User.Identity?.IsAuthenticated ?? false;

        public User GetUser()
        {
            var userId = GetUserId();
            return _userRepository.Get(userId)!;
        }

        public string GetUserName()
            => GetClaimValue(AuthClaimsConstants.NAME);

        public int GetUserId()
        {
            var userIdText = GetClaimValue(AuthClaimsConstants.ID);
            var userId = int.Parse(userIdText);
            return userId;
        }
        public bool IsAdmin()
        {
            return IsAuthenticated() && GetUserRole() == UserRole.Admin;
        }
        public UserRole GetUserRole()
        {
            var userRole = GetClaimValue(AuthClaimsConstants.USER_ROLE);
            return Enum.Parse<UserRole>(userRole);
        }

        private string GetClaimValue(string claimType)
            => _httpContextAccessor
                .HttpContext!
                .User
                .Claims
                .First(x => x.Type == claimType)
                .Value;
    }
}
