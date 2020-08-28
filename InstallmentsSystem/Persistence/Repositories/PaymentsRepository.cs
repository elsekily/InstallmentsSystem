using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence.Repositories
{
    public class PaymentsRepository : IPaymentRepository
    {
        private readonly InstallmentsSystemDbContext context;

        public PaymentsRepository(InstallmentsSystemDbContext context)
        {
            this.context = context;
        }
        public void Add(Payment payment)
        {
            context.Payments.Add(payment);
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await context.Payments.Where(p => p.Id == id).SingleOrDefaultAsync();
        }

        public void Remove(Payment payment)
        {
            context.Payments.Remove(payment);
        }
    }
}
