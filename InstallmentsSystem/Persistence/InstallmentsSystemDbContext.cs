using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence
{
    public class InstallmentsSystemDbContext : DbContext
    {
        public InstallmentsSystemDbContext(DbContextOptions<InstallmentsSystemDbContext> options)
        : base(options)
        {
            
        }
    }
}
