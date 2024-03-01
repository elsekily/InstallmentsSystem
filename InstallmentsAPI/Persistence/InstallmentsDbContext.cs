using InstallmentsAPI.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstallmentsAPI.Persistence;
public class InstallmentsDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
    UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Installment> Installments { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public InstallmentsDbContext(DbContextOptions<InstallmentsDbContext> options)
    : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Installment>().HasOne(i => i.Client).WithMany(c => c.Installments);
        builder.Entity<Payment>().HasOne(p => p.Installment).WithMany(i => i.Payments);
        builder.Entity<UserRole>()
       .HasOne(ur => ur.User)
       .WithMany(u => u.Roles)
       .HasForeignKey(ur => ur.UserId);

        builder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.User)
            .HasForeignKey(ur => ur.RoleId);
    }
}