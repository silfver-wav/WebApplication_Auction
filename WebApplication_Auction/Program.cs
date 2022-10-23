using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.Persistence;
using Microsoft.AspNetCore.Identity;
using WebApplication_Auction.Persistence;
using WebApplication_Auction.Core.Interfaces;
using System.Security.Claims;
using WebApplication_Auction.Areas.Identity.Data.Core.Interfaces;
using WebApplication_Auction.Areas.Identity.Data.Core;
using WebApplication_Auction.Areas.Identity.Data.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();
builder.Services.AddScoped<IBidPersistence, BidSqlPersistence>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPersistence, UserPersistence>();


// db, with dependency injection
builder.Services.AddDbContext<AuctionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));

// identity configuration
// the first statement is missing from the scaffolding
builder.Services.AddDbContext<ProjectAppIdentityContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionAppIdentityContextConnection")));
builder.Services.AddDefaultIdentity<ProjectAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<ProjectAppIdentityContext>();

// add auto mapper scanning (requires AutoMapper package)
builder.Services.AddAutoMapper(typeof(Program));

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
app.MapRazorPages();
app.Run();
