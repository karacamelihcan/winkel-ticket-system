using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Context;
using WinkelTicket.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WinkelDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDb"), 
    sqlOptions => {
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(WinkelDbContext)).GetName().Name);
    });
});

builder.Services.AddAuthentication();

builder.Services.AddIdentity<User,UserRoles>(options => {
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<WinkelDbContext>()
.AddDefaultTokenProviders();

var cookieBuilder = new CookieBuilder(){
    Name = "panel.winkel.com.tr",
    HttpOnly = false,
    SameSite = SameSiteMode.Lax,
    SecurePolicy = CookieSecurePolicy.SameAsRequest
};

builder.Services.ConfigureApplicationCookie(options => {
        options.LoginPath = new PathString("/Account/Login");
        options.LogoutPath = new PathString("/Account/LogOut");
        options.Cookie = cookieBuilder;
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = System.TimeSpan.FromDays(30);
        options.AccessDeniedPath = new PathString("/Home/AccessDenied");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
