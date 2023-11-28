using Microsoft.AspNetCore.Identity;
using System.Net;
using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;

namespace OpeniddictServer.Data
{
    public class IdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, IAdminService rsAdminService)
        {
            if (!userManager.Users.Any()) //aspnetusers
            {
                var user = new ApplicationUser
                {
                    Email = "lupusvlad@gmail.com",
                    UserName = "lupusvlad@gmail.com",
                    PictureUrl = null,
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");

                var rsUser = User.Create(new Guid(user.Id), user.Email, user.Email);
                await rsAdminService.RegisterUser(rsUser);
            }
        }
    }
}
