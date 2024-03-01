using InstallmentsAPI.Core;
using InstallmentsAPI.Entities.Models;
using InstallmentsAPI.Entities.Resources;
using Microsoft.EntityFrameworkCore;

namespace InstallmentsAPI.Persistence.Repositories;

public class PaymentsRepository : IPaymentRepository
{
    private readonly InstallmentsDbContext context;

    public PaymentsRepository(InstallmentsDbContext context)
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