using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IProductService, ProductService>(c => 
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceUrls:ProductAPI"))
);

builder.Services.AddAuthentication(op =>
{
    op.DefaultScheme = "Cookies";
    op.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", op =>
    {
        op.Authority = builder.Configuration.GetValue<string>("ServiceUrls:IdentityServer");
        op.GetClaimsFromUserInfoEndpoint = true;
        op.ClientId = "geek_shopping";
        op.ClientSecret = "fadshdgsGFASDGqdfafgYHJmnGbb635423GHGK8%35rrwrw";
        op.ResponseType = "code";
        op.ClaimActions.MapJsonKey("role", "role", "role");
        op.ClaimActions.MapJsonKey("sub", "sub", "sub");
        op.TokenValidationParameters.NameClaimType = "name";
        op.TokenValidationParameters.RoleClaimType = "role";
        op.Scope.Add("geek_shopping");
        op.SaveTokens = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
