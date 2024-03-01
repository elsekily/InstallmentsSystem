using InstallmentsAPI.Core;
using InstallmentsAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InstallmentsAPI.Persistence.Repositories;
public class ClientsRepository : IClientRepository
{
    private readonly InstallmentsDbContext context;

    public ClientsRepository(InstallmentsDbContext context)
    {
        this.context = context;
    }
    public void Add(Client client)
    {
        context.Clients.Add(client);
    }

    public async Task<Client> GetClient(int id)
    {
        return await context.Clients.Where(c => c.Id == id)
            .Include(c => c.Installments).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Client>> GetClients()
    {
        return await context.Clients.ToListAsync();
    }

    public void Remove(Client client)
    {
        context.Remove(client);
    }
}