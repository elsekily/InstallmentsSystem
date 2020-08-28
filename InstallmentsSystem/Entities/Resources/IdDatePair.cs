using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstallmentsSystem.Entities.Resources
{
    public class IdDatePair
    {
        [Required]
        public int InstallmentId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
