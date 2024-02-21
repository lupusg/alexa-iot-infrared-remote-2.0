using System.Globalization;
using OpenIddict.Abstractions;
using OpeniddictServer.Data;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace OpeniddictServer
{
    public class Worker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);

            await RegisterApplicationsAsync(scope.ServiceProvider);
            await RegisterScopesAsync(scope.ServiceProvider);

            static async Task RegisterApplicationsAsync(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<IOpenIddictApplicationManager>();

                // Angular UI client
                if (await manager.FindByClientIdAsync("aiirui") is null)
                {
                    await manager.CreateAsync(new OpenIddictApplicationDescriptor
                    {
                        ClientId = "aiirui",
                        ConsentType = ConsentTypes.Explicit,
                        DisplayName = "Alexa IoT Infrared Remote UI",
                        DisplayNames =
                        {
                            [CultureInfo.GetCultureInfo("en-US")] = "Alexa IoT Infrared Remote UI"
                        },
                        PostLogoutRedirectUris =
                        {
                            new Uri("https://localhost:4200"),
                            new Uri("https://yellow-stone-0df16c003.3.azurestaticapps.net")
                        },
                        RedirectUris =
                        {
                            new Uri("https://localhost:4200"),
                            new Uri("https://yellow-stone-0df16c003.3.azurestaticapps.net")
                        },
                        Permissions =
                        {
                            Permissions.Endpoints.Authorization,
                            Permissions.Endpoints.Logout,
                            Permissions.Endpoints.Token,
                            Permissions.Endpoints.Revocation,
                            Permissions.GrantTypes.AuthorizationCode,
                            Permissions.GrantTypes.RefreshToken,
                            Permissions.ResponseTypes.Code,
                            Permissions.Scopes.Email,
                            Permissions.Scopes.Profile,
                            Permissions.Scopes.Roles,
                            Permissions.Prefixes.Scope + "dataAIIR"
                        },
                        Requirements =
                        {
                            Requirements.Features.ProofKeyForCodeExchange
                        }
                    });
                }

                //swagger
                if (await manager.FindByClientIdAsync("swaggerui") is null)
                {
                    await manager.CreateAsync(new OpenIddictApplicationDescriptor
                    {
                        ClientId = "swaggerui",
                        ConsentType = ConsentTypes.Explicit,
                        DisplayName = "Swagger UI",
                        DisplayNames =
                        {
                            [CultureInfo.GetCultureInfo("en-EN")] = "Swagger UI"
                        },
                        PostLogoutRedirectUris =
                        {
                            new Uri("https://localhost:5001/swagger/oauth2-redirect.html")
                        },
                        RedirectUris =
                        {
                            new Uri("https://localhost:5001/swagger/oauth2-redirect.html")
                        },
                        Permissions =
                        {
                            Permissions.Endpoints.Authorization,
                            Permissions.Endpoints.Logout,
                            Permissions.Endpoints.Token,
                            Permissions.Endpoints.Revocation,
                            Permissions.GrantTypes.AuthorizationCode,
                            Permissions.GrantTypes.RefreshToken,
                            Permissions.ResponseTypes.Code,
                            Permissions.Scopes.Email,
                            Permissions.Scopes.Profile,
                            Permissions.Scopes.Roles,
                            Permissions.Prefixes.Scope + "dataAIIR",
                        },
                        Requirements =
                        {
                            Requirements.Features.ProofKeyForCodeExchange
                        }
                    });
                }

                // API
                if (await manager.FindByClientIdAsync("rs_dataAIIR") == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "rs_dataAIIR",
                        ClientSecret = "dataAIIRSecret",
                        Permissions =
                        {
                            Permissions.Endpoints.Introspection
                        }
                    };

                    await manager.CreateAsync(descriptor);
                }
            }

            static async Task RegisterScopesAsync(IServiceProvider provider)
            {
                var manager = provider.GetRequiredService<IOpenIddictScopeManager>();

                if (await manager.FindByNameAsync("dataAIIR") is null)
                {
                    await manager.CreateAsync(new OpenIddictScopeDescriptor
                    {
                        DisplayName = "AIIR Resource Server",
                        DisplayNames =
                        {
                            [CultureInfo.GetCultureInfo("en-US")] = "AIIR Resource Server"
                        },
                        Name = "dataAIIR",
                        Resources =
                        {
                            "rs_dataAIIR"
                        }
                    });
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
