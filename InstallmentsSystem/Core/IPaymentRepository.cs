using InstallmentsSystem.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Core
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        void Remove(Payment payment);
    }
}
