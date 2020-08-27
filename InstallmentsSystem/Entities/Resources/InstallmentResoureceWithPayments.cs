using System.Collections.Generic;

namespace InstallmentsSystem.Entities.Resources
{
    public class InstallmentResoureceWithPayments : InstallmentResourece
    {
        public IList<PaymentResource> Payments { get; set; }
        public InstallmentResoureceWithPayments()
        {
            Payments = new List<PaymentResource>();
        }
    }
}
