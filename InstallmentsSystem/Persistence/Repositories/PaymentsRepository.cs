using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using InstallmentsSystem.Entities.Resources;
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
            var installment = context.Installments.Where(i => i.Id == payment.InstallmentId)
                .Include(i => i.Payments).SingleOrDefaultAsync().Result;

            installment.Remaining -= payment.Amount;
            payment.MonthNumber = installment.Payments.Count + 1;

            while ((installment.NextPayment - DateTime.Now).Days < 20)  
                installment.NextPayment = SetNextPayment
                    .Date(installment.DayofPayment, installment.NextPayment);

            context.Payments.Add(payment);
        }

        public void Remove(Payment payment)
        {
            var installment = context.Installments.Where(i => i.Id == payment.InstallmentId)
                .Include(i => i.Payments).SingleOrDefaultAsync().Result;

            installment.Remaining += payment.Amount;
            context.Payments.Remove(payment);
            installment.NextPayment = DateTime.Now;
        }
    }
}