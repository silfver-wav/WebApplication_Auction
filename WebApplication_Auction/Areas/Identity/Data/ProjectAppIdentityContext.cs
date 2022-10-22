﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectApp.Areas.Identity.Data;
using System.Reflection.Emit;

namespace ProjectApp.Data;

public class ProjectAppIdentityContext : IdentityDbContext<ProjectAppUser>
{
    public ProjectAppIdentityContext(DbContextOptions<ProjectAppIdentityContext> options)
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
