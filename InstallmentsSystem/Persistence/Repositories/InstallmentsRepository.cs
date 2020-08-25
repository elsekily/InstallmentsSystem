using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Persistence.Repositories
{
    public class InstallmentsRepository : IInstallmentRepository
    {
        private readonly InstallmentsSystemDbContext context;

        public InstallmentsRepository(InstallmentsSystemDbContext context)
        {
            this.context = context;
        }
        public void Add(Installment installment)
        {
            throw new NotImplementedException();
        }

        public Task<Installment> GetInstallment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Installment>> GetInstallments()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Installment>> GetLateInstallments()
        {
            //return context.installments.Where(d=>d.InstallDate.day)
            throw new NotImplementedException();
        }

        public void Remove(Installment installment)
        {
            throw new NotImplementedException();
        }
    }
}
