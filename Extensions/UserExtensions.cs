using System.Security.Claims;

namespace AvtoElon.API.Demo.Extensions
{
    public static class UserExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"))!.Value;
        }

    }
}
