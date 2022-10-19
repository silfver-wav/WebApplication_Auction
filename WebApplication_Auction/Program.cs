using Microsoft.EntityFrameworkCore;
using WebApplication_Auction.Core;
using WebApplication_Auction.Core.Interfaces;
using WebApplication_Auction.Persistence;
using Microsoft.AspNetCore.Identity;
using WebApplication_Auction.Data;
using WebApplication_Auction.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();


// db, with dependency injection
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));


builder.Services.AddDbContext<WebApplication_AuctionIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication_AuctionIdentityContextConnection")));

builder.Services.AddDbContext<WebApplication_AuctionIdentityContext>(options => options.EnableSensitiveDataLogging());

builder.Services.AddDefaultIdentity<WebApplication_AuctionUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebApplication_AuctionIdentityContext>();


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

app.Run();
