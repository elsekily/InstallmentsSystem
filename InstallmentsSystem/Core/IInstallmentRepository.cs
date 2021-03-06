﻿using InstallmentsSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Core
{
    public interface IInstallmentRepository
    {
        Task<IEnumerable<Installment>> GetClientInstallments(int clientId);
        Task<IEnumerable<Installment>> GetInstallments();
        Task<IEnumerable<Installment>> GetLateStillRemainingInstallments();
        Task<Installment> GetInstallment(int id);
        void Add(Installment installment);
        void Remove(Installment installment);
    }
}
