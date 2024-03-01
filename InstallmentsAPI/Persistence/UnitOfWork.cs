using InstallmentsAPI.Core;

namespace InstallmentsAPI.Persistence;
public class UnitOfWork : IUnitOfWork
{
    private readonly InstallmentsDbContext context;

    public UnitOfWork(InstallmentsDbContext context)
    {
        this.context = context;
    }
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}