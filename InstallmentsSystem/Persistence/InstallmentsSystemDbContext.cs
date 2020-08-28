using InstallmentsSystem.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstallmentsSystem.Persistence
{
    public class InstallmentsSystemDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public InstallmentsSystemDbContext(DbContextOptions<InstallmentsSystemDbContext> options)
        : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Installment>().HasOne(i => i.Client).WithMany(c => c.Installments);
            builder.Entity<Payment>().HasOne(p => p.Installment).WithMany(i => i.Payments);
        }
    }
}
