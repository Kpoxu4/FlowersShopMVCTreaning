﻿using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Interface;


namespace FlowersShopMVCTraining.Service.AuthStuff
{
    public class AuthService : IAuthService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IUserRepository _userRepository;

        public AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
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
