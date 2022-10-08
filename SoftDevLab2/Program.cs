using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoftDevLab2.Data;
using SoftDevLab2.Models;

var builder = WebApplication.CreateBuilder(args);
var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("OnlineConnection"));
conStrBuilder.Password = builder.Configuration["DbPass"];
var connection = conStrBuilder.ConnectionString; // this is the final conn string

// Add services to the container.
var connectionString = connection;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

/*builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    DbInitializer.SeedUsersAndRoles(scope.ServiceProvider).Wait();
}*/
using (var scope = app.Services.CreateScope())
{
    
    //userManager.AddToRoleAsync(user as ApplicationUser, "Manager");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
