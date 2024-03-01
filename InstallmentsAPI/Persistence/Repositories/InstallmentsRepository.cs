using InstallmentsAPI.Core;
using InstallmentsAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InstallmentsAPI.Persistence.Repositories;

public class InstallmentsRepository : IInstallmentRepository
{
    private readonly InstallmentsDbContext context;

    public InstallmentsRepository(InstallmentsDbContext context)
    {
        this.context = context;
    }
    public async void Add(Installment installment)
    {
        await context.Installments.AddAsync(installment);
    }

    public async Task<IEnumerable<Installment>> GetClientInstallments(int clientId)
    {
        return await context.Installments.Where(i => i.ClientId == clientId)
            .Include(i => i.Client).ToListAsync();
    }

    public async Task<Installment> GetInstallment(int id)
    {
        return await context.Installments.Where(i => i.Id == id)
            .Include(i => i.Payments).Include(i => i.Client).SingleOrDefaultAsync();
    }
    public async Task<IEnumerable<Installment>> GetInstallments()
    {
        return await context.Installments
            .Include(i => i.Client).ToListAsync();
    }
    public async Task<IEnumerable<Installment>> GetLateStillRemainingInstallments()
    {
        return await context.Installments.Where(i => i.NextPayment < DateTime.Now && i.Remaining > 0)
            .Include(i => i.Client).OrderByDescending(i => i.NextPayment).ToListAsync();
    }
    public void Remove(Installment installment)
    {
        context.Installments.Remove(installment);
    }
}