using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Entities.Models
{
    public class Installment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public string DeviceName { get; set; }
        public int DeviceActualPrice { get; set; }
        public int PaymentScheme { get; set; }
        public int DevicePrice { get; set; }
        public int FirstInstallment { get; set; }
        public int Remaining { get; set; }
        public int MontlyPayment { get; set; }
        [Range(1,31)]
        public int DayofPayment { get; set; }
        public DateTime NextPayment { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public IList<Payment> Payments { get; set; }
        public Installment()
        {
            Payments = new List<Payment>();
        }
    }
}
