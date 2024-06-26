using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;
using OpeniddictServer.Data;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Microsoft.IdentityModel.Logging;
using AlexaIOTInfraredRemoteAPI.Application.Services;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

namespace OpeniddictServer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            // Configure the context to use Microsoft SQL Server.
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            // Register the entity sets needed by OpenIddict.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            options.UseOpenIddict();
        });

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddClaimsPrincipalFactory<CustomUserClaimsPrincipalFactory>();

        services.AddDistributedMemoryCache();

        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBoardRepository, BoardRepository>();
        services.AddScoped<IInfraredSignalRepository, InfraredSignalRepository>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        services.AddDbContext<AiirContext>(options =>
         {
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
         });

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(2);
            options.Cookie.HttpOnly = true;
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        services.Configure<IdentityOptions>(options =>
        {
            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            options.ClaimsIdentity.UserNameClaimType = Claims.Name;
            options.ClaimsIdentity.UserIdClaimType = Claims.Subject;
            options.ClaimsIdentity.RoleClaimType = Claims.Role;
            options.ClaimsIdentity.EmailClaimType = Claims.Email;

            // Note: to require account confirmation before login,
            // register an email sender service (IEmailSender) and
            // set options.SignIn.RequireConfirmedAccount to true.
            //
            // For more information, visit https://aka.ms/aspaccountconf.
            options.SignIn.RequireConfirmedAccount = false;
        });

        // OpenIddict offers native integration with Quartz.NET to perform scheduled tasks
        // (like pruning orphaned authorizations/tokens from the database) at regular intervals.
        services.AddQuartz(options =>
        {
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder
                        .AllowCredentials()
                        .WithOrigins(
                            "https://localhost:4200", "https://localhost:4204",
                            "https://yellow-stone-0df16c003.3.azurestaticapps.net/",
                            "https://localhost:5001",
                            "https://iot-infrared-remote.com/")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddAuthentication().AddGoogle(googleOptions =>
        {
            googleOptions.ClientId = Configuration["Authentication:Google:ClientId"] ?? throw new Exception("Google client id is null.");
            googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"] ?? throw new Exception("Google client  is null."); ;
            googleOptions.ClaimActions.MapJsonKey("picture", "picture", "url");
        });

        services.AddOpenIddict()
            .AddCore(options =>
            {
                options.UseEntityFrameworkCore()
                       .UseDbContext<ApplicationDbContext>();

                options.UseQuartz();
            })
            .AddServer(options =>
            {
                // Enable the authorization, logout, token and userinfo endpoints.
                options.SetAuthorizationEndpointUris("connect/authorize")
                   //.SetDeviceEndpointUris("connect/device")
                   .SetIntrospectionEndpointUris("connect/introspect")
                   .SetLogoutEndpointUris("connect/logout")
                   .SetTokenEndpointUris("connect/token")
                   .SetUserinfoEndpointUris("connect/userinfo")
                   .SetVerificationEndpointUris("connect/verify");

                options.AllowAuthorizationCodeFlow()
                       .AllowHybridFlow()
                       .AllowClientCredentialsFlow()
                       .AllowRefreshTokenFlow();

                options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles, "dataAIIR");

                options.RegisterClaims(Claims.Picture);

                options.AddEphemeralEncryptionKey()
                       .AddEphemeralSigningKey();

                options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableLogoutEndpointPassthrough()
                       .EnableTokenEndpointPassthrough()
                       .EnableUserinfoEndpointPassthrough()
                       .EnableStatusCodePagesIntegration();
            })
            .AddValidation(options =>
            {
                options.UseLocalServer();
                options.UseAspNetCore();
            });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

            // Set up JWT Bearer authentication for Swagger
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        services.AddHostedService<Worker>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        IdentityModelEventSource.ShowPII = true;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
        else
        {
            app.UseStatusCodePagesWithReExecute("~/error");
            //app.UseExceptionHandler("~/error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
        }

        app.UseCors("AllowAllOrigins");

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSession();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
        });

        SeedData(app);
    }


    public async void SeedData(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        //var context = services.GetRequiredService<ApplicationDbContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        //var userManager = services.GetService<UserManager<ApplicationUser>>();
        //var userService = services.GetService<IAdminService>();
        var roles = new[] { "Admin", "User", "Board" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        try
        {
            //await context.Database.MigrateAsync();
            //await IdentityDbContextSeed.SeedUsersAsync(userManager, userService );
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating or seeding the identity database.");
        }
    }
}
