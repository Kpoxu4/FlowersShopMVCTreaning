using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using System.Security;

namespace FlowersShopMVCTraining.Service
{
    public class AuthStuff
    {
        private IHttpContextAccessor _httpContextAccessor;
        private UserRepository _userRepository;

        public AuthStuff(IHttpContextAccessor httpContextAccessor, UserRepository userRepository)
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

        private string GetClaimValue(string claimType)
            => _httpContextAccessor
                .HttpContext!
                .User
                .Claims
                .First(x => x.Type == claimType)
                .Value;
    }
}
