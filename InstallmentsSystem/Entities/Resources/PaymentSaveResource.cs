using System.ComponentModel.DataAnnotations;

namespace InstallmentsSystem.Entities.Resources
{
    public class PaymentSaveResource
    {
        [Required]
        public int InstallmentId { get; set; }
        [Required]
        public int Amount { get; set; }
        [MaxLength(255)]
        public string Detials { get; set; }
    }
}
