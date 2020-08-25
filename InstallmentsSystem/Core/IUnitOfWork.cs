using System.Threading.Tasks;

namespace InstallmentsSystem.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
