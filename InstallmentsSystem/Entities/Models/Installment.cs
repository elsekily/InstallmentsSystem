using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Entities.Models
{
    public class Installment
    {
        public int Id { get; set; }
        public DateTime InstallDate { get; set; }
        public string DeviceName { get; set; }
        public int DeviceActualPrice { get; set; }
        [DisplayName("النظام")]
        public int PaymentScheme { get; set; }
        [DisplayName("السعر بعد دفع الاقساط")]
        public int DevicePrice { get; set; }
        [DisplayName("المقدم")]
        public int FirstInstallment { get; set; }
        [DisplayName("الباقي")]
        public int Remaining { get; set; }
        [DisplayName("القسط")]
        public int MontlyPayment { get; set; }
        public IList<InstallmentClients> Clients { get; set; }
        public IList<Payment> Payments { get; set; }
        public Installment()
        {
            Payments = new List<Payment>();
            Clients = new List<InstallmentClients>();
        }
    }
}
