using Application;
using Domain.Entities;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Persistence;
using Persistence.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);
builder.Services.AddDefaultIdentity<AppUser>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    })
    .AddRoles<AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
