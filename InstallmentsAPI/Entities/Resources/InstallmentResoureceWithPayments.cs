using System.Collections.Generic;


namespace InstallmentsAPI.Entities.Resources;
public class InstallmentResoureceWithPayments : InstallmentResourece
{
    public IList<PaymentResource> Payments { get; set; }
    public InstallmentResoureceWithPayments()
    {
        Payments = new List<PaymentResource>();
    }
}
