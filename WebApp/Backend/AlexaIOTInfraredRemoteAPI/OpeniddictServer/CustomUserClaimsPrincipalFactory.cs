using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OpeniddictServer.Data;
using System.Security.Claims;

namespace OpeniddictServer
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var identity = (ClaimsIdentity)principal.Identity;

            if (!string.IsNullOrEmpty(user.PictureUrl))
            {
                identity.AddClaim(new Claim("picture", user.PictureUrl));
            }

            return principal;
        }
    }
}
