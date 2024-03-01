using InstallmentsAPI.Entities.Models;

namespace InstallmentsAPI.Core;

public interface IInstallmentRepository
{
    Task<IEnumerable<Installment>> GetClientInstallments(int clientId);
    Task<IEnumerable<Installment>> GetInstallments();
    Task<IEnumerable<Installment>> GetLateStillRemainingInstallments();
    Task<Installment> GetInstallment(int id);
    void Add(Installment installment);
    void Remove(Installment installment);
}