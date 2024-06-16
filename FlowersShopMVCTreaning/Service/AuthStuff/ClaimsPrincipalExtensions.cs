using System.Security.Claims;

namespace FlowersShopMVCTraining.Service.AuthStuff
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsInCustomRole(this ClaimsPrincipal principal, string role)
        {
            return principal.Claims.Any(c => c.Type == AuthClaimsConstants.USER_ROLE && c.Value == role);
        }
    }
}
