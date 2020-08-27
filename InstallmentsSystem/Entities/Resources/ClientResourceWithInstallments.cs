using System.Collections.Generic;

namespace InstallmentsSystem.Entities.Resources
{
    public class ClientResourceWithInstallments : ClientResource
    {
        public IList<InstallmentResourece> Installments { get; set; }
        public ClientResourceWithInstallments()
        {
            Installments = new List<InstallmentResourece>();
        }
        
    }
}
