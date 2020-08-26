using InstallmentsSystem.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Core
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment> GetPayment(int id);
        void Add(Payment payment);
        void Remove(Payment payment);
    }
}
