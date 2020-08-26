using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence.Repositories
{
    public class PaymentsRepository : IPaymentRepository
    {
        public void Add(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetPayment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetPayments()
        {
            throw new NotImplementedException();
        }

        public void Remove(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
