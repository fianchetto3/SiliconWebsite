
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiliconInfrastructure.Entities;

namespace SiliconInfrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UserEntity>(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AddressEntity>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<AddressEntity>()
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<UserEntity>()
             .HasOne(u => u.Address)
             .WithMany(a => a.Users)
             .HasForeignKey(u => u.AddressId);

    }
}
