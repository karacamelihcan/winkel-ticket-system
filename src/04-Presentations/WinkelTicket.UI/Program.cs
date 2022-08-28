using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WinkelTicket.Core.Models;
using WinkelTicket.Database.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WinkelDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalDb"), 
    sqlOptions => {
        sqlOptions.MigrationsAssembly(Assembly.GetAssembly(typeof(WinkelDbContext)).GetName().Name);
    });
});

builder.Services.AddIdentity<User,UserRoles>()
                .AddEntityFrameworkStores<WinkelDbContext>();

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
