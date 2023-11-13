using AlexaIOTInfraredRemoteAPI.Extensions;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using AlexaIOTInfraredRemoteAPI.Openiddict;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        builder.Services.AddControllers();
        builder.Services.AddApplicationServices(builder.Configuration);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AiirContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder
                        .AllowCredentials()
                        .WithOrigins(
                            "https://localhost:4200",
                            "https://aiir-web2.azurewebsites.net/"
                            )
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        var guestPolicy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "dataAIIR")
            .Build();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });

        builder.Services.AddOpenIddict()
            .AddValidation(options =>
            {
                options.SetIssuer(builder.Configuration["Openiddict:Issuer"] ?? throw new ArgumentException("Issuer is null."));
                options.AddAudiences("rs_dataAIIR");
                options.UseIntrospection()
                    .SetClientId("rs_dataAIIR")
                    .SetClientSecret("dataAIIRSecret");
                options.UseSystemNetHttp();
                options.UseAspNetCore();
            });

        builder.Services.AddScoped<IAuthorizationHandler, RequireScopeHandler>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("dataAIIRPolicy", policyUser =>
            {
                policyUser.Requirements.Add(new RequireScope());
            });
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "AlexaIOTInfraredRemoteAPI",
                Version = "v1",
                Description = ""
            });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://localhost:44395/connect/authorize"),
                        TokenUrl = new Uri("https://localhost:44395/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            { "openid", "OpenID" },
                            { "profile", "Profile" },
                            { "email", "Email" },
                            { "roles", "Roles" },
                            { "dataAIIR", "dataAIIR" }
                        }
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        }
                    },
                    new[] { "openid", "profile", "email", "roles" , "dataAIIR" }
                }
            });
        });

        builder.Services.AddControllers()
            .AddNewtonsoftJson();

        if (builder.Environment.IsDevelopment())
        {
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.UseHttps("mycert.pfx", "test123");
                });
            });
        }

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.Urls.Add("https://0.0.0.0:5001");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIIR Resource Server");
                c.RoutePrefix = "swagger";
                c.OAuthClientId("swaggerui");
                c.OAuthUsePkce();
                c.OAuthClientSecret("");
                c.OAuthAppName("Swagger UI");
                c.OAuthScopes("openid", "profile", "email", "roles", "dataAIIR");
            });
        }

        app.UseExceptionHandler("/Home/Error");
        app.UseCors("AllowAllOrigins");
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        SeedData(app);


        app.Run();
    }

    public static async void SeedData(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AiirContext>();
        var logger = services.GetRequiredService<ILogger<Program>>();

        try
        {
            await context.Database.MigrateAsync();
            await AiirContextSeed.SeedAsync(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
    }
}