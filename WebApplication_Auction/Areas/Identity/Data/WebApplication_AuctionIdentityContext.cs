﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication_Auction.Areas.Identity.Data;

namespace WebApplication_Auction.Data;

public class WebApplication_AuctionIdentityContext : IdentityDbContext<WebApplication_AuctionUser>
{
    public WebApplication_AuctionIdentityContext(DbContextOptions<WebApplication_AuctionIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
