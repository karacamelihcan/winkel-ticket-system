using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NLog;
using NLog.Web;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Context;
using WinkelTicket.Database.Repositories.UserRepositories;
using WinkelTicket.Database.UnitOfWorks;
using WinkelTicket.Services.Providers;
using WinkelTicket.Services.Services.UserServices;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    
    //Repositories
    builder.Services.AddScoped<IUserRepository,UserRepository>();

    //Services
    builder.Services.AddScoped<IClaimsTransformation,ClaimProvider>();
    builder.Services.AddScoped<IUserService,UserService>();

    //Unit Of Work
    builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

    builder.Services.AddDbContext<WinkelDbContext>(options => {
        options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDb"), 
        sqlOptions => {
            sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(WinkelDbContext)).GetName().Name);
        });
    });

    builder.Services.AddAuthorization(options => {
        options.AddPolicy("AdminOnlyPolicy", policy => {
            policy.RequireClaim(ClaimTypes.Role,"Admin");
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
            options.LoginPath = new PathString("/Account/LogIn");
            options.LogoutPath = new PathString("/Account/LogOut");
            options.Cookie = cookieBuilder;
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = System.TimeSpan.FromDays(30);
            options.AccessDeniedPath = new PathString("/Home/AccessDenied");
    });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

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
        pattern: "{controller=Account}/{action=LogIn}/{id?}");

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

