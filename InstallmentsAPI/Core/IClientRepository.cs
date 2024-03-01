using InstallmentsAPI.Entities.Models;

namespace InstallmentsAPI.Core;
public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClients();
    Task<Client> GetClient(int id);
    void Add(Client client);
    void Remove(Client client);
}