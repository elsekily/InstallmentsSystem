using InstallmentsSystem.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Core
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        void Add(Client client);
        void Remove(Client client);
    }
}
