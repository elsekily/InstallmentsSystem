using System.Threading.Tasks;

namespace InstallmentsAPI.Core;

public interface IUnitOfWork
{
    Task CompleteAsync();
}