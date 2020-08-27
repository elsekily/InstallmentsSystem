using InstallmentsSystem.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Entities.Resources
{
    public class InstallmentSaveResource
    {
        [MaxLength(255)]
        [Required]
        public string DeviceName { get; set; }
        public int DeviceActualPrice { get; set; }
        [Required]
        public int PaymentScheme { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int DevicePrice { get; set; }
        [Required]
        public int FirstInstallment { get; set; }
        [Range(1, int.MaxValue)]
        public int MontlyPayment { get; set; }
        [Required]
        [Range(1, 31)]
        public int DayofPayment { get; set; }
        [Required]
        public int ClientId { get; set; }
    }
}
