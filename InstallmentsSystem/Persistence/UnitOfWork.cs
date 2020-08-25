using InstallmentsSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InstallmentsSystemDbContext context;

        public UnitOfWork(InstallmentsSystemDbContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
