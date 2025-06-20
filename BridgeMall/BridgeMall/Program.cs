using BridgeMall.Client.Pages;
using BridgeMall.Components;
using BridgeMall.Services.DB;
using BridgeMall.Services.Interfaces;
using BridgeMall.Models.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BridgeMall.Models.Configuration;
using Blazored.LocalStorage;
using BridgeMall.Helpers;
using BridgeMall.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddHttpClient();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"/home/app/.aspnet/DataProtection-Keys"));

if (OperatingSystem.IsWindows())
{
    builder.Services.AddDataProtection()
        .ProtectKeysWithDpapi();
}

// Add controllers to the container
builder.Services.AddControllers();

// Add Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Register Helper classes
builder.Services.AddScoped<MessageBoxHelper>();

// Add AuthenticationStateprovider
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// Register local services from referenced projects
builder.Services.AddModels(builder.Configuration);

// Register services for the BookingService
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();


// Register third-party services
builder.Services.AddFluentUIComponents();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthenticationCore();
// Add JWT Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var jwtConfig = builder.Configuration.GetRequiredSection(nameof(JwtConfig)).Get<JwtConfig>();
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig!.Key)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuers =
        [
            jwtConfig.Issuers.Local,
            jwtConfig.Issuers.Hosted,
            jwtConfig.Issuers.Temp,
        ],
        ValidAudiences =
        [
            jwtConfig.Issuers.Local,
            jwtConfig.Issuers.Hosted,
            jwtConfig.Issuers.Temp,
        ]
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BridgeMall.Client._Imports).Assembly);

app.Run();
