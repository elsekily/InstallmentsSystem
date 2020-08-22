using System.Collections.Generic;

namespace InstallmentsSystem.Entities.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientNationalId { get; set; }
        public string MobileNumber { get; set; }
        public IList<InstallmentClients> Installments{ get; set; }
        public Client()
        {
            Installments = new List<InstallmentClients>();
        }
    }
}
