using InstallmentsSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Entities.Resources
{
    public class InstallmentSaveResource
    {
        public string DeviceName { get; set; }
        public int DeviceActualPrice { get; set; }
        public int PaymentScheme { get; set; }
        public int DevicePrice { get; set; }
        public int FirstInstallment { get; set; }
        public int MontlyPayment { get; set; }
        public int DayofPayment { get; set; }
        public int ClientId { get; set; }
    }
}
