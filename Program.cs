using Microsoft.EntityFrameworkCore;
using TP11Core.Models;
using Microsoft.AspNetCore.Identity;
using authentication_app.Data;
using TP11Core.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<authentication_appContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("authentication_appContextConnection")));
builder.Services.AddDefaultIdentity<Admin>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<authentication_appContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
