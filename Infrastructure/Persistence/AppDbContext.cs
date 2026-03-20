using Domain.Modal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Company> Company => Set<Company>();
    protected override void OnModelCreating(ModelBuilder mb)
    {
        // ─── Company ───────────────────────────────
        mb.Entity<Company>(e =>
        {
            e.ToTable("Company", "public");  
            e.HasKey(c => c.Id);
        });

        // ─── User ──────────────────────────────────
        mb.Entity<User>(e =>
        {
            e.ToTable("User", "public");     // 
            e.HasKey(u => u.Id);
            e.HasIndex(u => u.Email).IsUnique();
            e.Property(u => u.Role).HasConversion<string>();
        });

        // ─── RefreshToken ──────────────────────────
        mb.Entity<RefreshToken>(e =>
        {
            e.ToTable("RefreshToken", "public");  // ← YEH BHI
            e.HasKey(r => r.Id);
            e.HasOne(r => r.User)
             .WithMany(u => u.RefreshTokens)
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(r => r.Token).IsUnique();
        });

        // ─── Relationship ──────────────────────────
        mb.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(e => e.Users)
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}