﻿using InstallmentsSystem.Core;
using InstallmentsSystem.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async void Add(Installment installment)
        {
            await context.installments.AddAsync(installment);
        }

        public async Task<IEnumerable<Installment>> GetClientInstallments(int clientId)
        {
            return await context.installments.Where(i => i.ClientId == clientId)
                .Include(i => i.Client).ToListAsync();
        }

        public async Task<Installment> GetInstallment(int id)
        {
            return await context.installments.Where(i => i.Id == id).Include(i => i.Payments)
                .Include(i => i.Client).SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<Installment>> GetInstallments()
        {
            return await context.installments
                .Include(i => i.Client).ToListAsync();
        }
        public async Task<IEnumerable<Installment>> GetLateInstallments()
        {
            return await context.installments.Where(i => i.NextPayment > DateTime.Now)
                .Include(i => i.Client).ToListAsync();
        }
        public void Remove(Installment installment)
        {
            context.installments.Remove(installment);
        }
    }
}
