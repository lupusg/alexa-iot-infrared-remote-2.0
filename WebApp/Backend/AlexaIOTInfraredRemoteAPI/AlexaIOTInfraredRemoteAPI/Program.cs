using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using AlexaIOTInfraredRemoteAPI.Openiddict;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AIIRDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowCredentials()
                .WithOrigins(
                    "https://localhost:4200", "https://aiir-web2.azurewebsites.net/")
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

// Register the OpenIddict validation components.
builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        // Note: the validation handler uses OpenID Connect discovery
        // to retrieve the address of the introspection endpoint.
        options.SetIssuer(builder.Configuration["Openiddict:Issuer"] ?? throw new ArgumentException("Issuer is null."));
        options.AddAudiences("rs_dataAIIR");

        // Configure the validation handler to use introspection and register the client
        // credentials used when communicating with the remote introspection endpoint.
        options.UseIntrospection()
                .SetClientId("rs_dataAIIR")
                .SetClientSecret("dataAIIRSecret");

        // Register the System.Net.Http integration.
        options.UseSystemNetHttp();

        // Register the ASP.NET Core host.
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
    // add JWT Authentication
    //var securityScheme = new OpenApiSecurityScheme
    //{
    //    Name = "JWT Authentication",
    //    Description = "Enter JWT Bearer token **_only_**",
    //    In = ParameterLocation.Header,
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "bearer", // must be lower case
    //    BearerFormat = "JWT",
    //    Reference = new OpenApiReference
    //    {
    //        Id = JwtBearerDefaults.AuthenticationScheme,
    //        Type = ReferenceType.SecurityScheme
    //    }
    //};
    //c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {securityScheme, new string[] { }}
    //});

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AlexaIOTInfraredRemoteAPI",
        Version = "v1",
        Description = ""
    });
});

builder.Services.AddControllers()
            .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AIIR Resource Server");
        c.RoutePrefix = "swagger";
    });
}

app.UseExceptionHandler("/Home/Error");
app.UseCors("AllowAllOrigins");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();