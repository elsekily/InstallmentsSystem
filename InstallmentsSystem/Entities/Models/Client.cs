using System.Collections.Generic;

namespace InstallmentsSystem.Entities.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Installment> Installments{ get; set; }
        public Client()
        {
            Installments = new List<Installment>();
        }
    }
}
