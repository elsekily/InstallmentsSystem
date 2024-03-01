using InstallmentsAPI.Entities.Models;

namespace InstallmentsAPI.Core;

public interface IPaymentRepository
{
    void Add(Payment payment);
    void Remove(Payment payment);
}