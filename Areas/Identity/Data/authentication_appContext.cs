using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Configuration;
using TP11Core.Areas.Identity.Data;

namespace authentication_app.Data;

public class authentication_appContext : IdentityDbContext<Admin>
{
    public authentication_appContext(DbContextOptions<authentication_appContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure (EntityTypeBuilder<Admin> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(10);
        builder.Property(x => x.LastName).HasMaxLength(10);

    }
}