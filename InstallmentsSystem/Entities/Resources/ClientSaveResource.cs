using System.ComponentModel.DataAnnotations;

namespace InstallmentsSystem.Entities.Resources
{
    public class ClientSaveResource
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string NationalId { get; set; }
        [MaxLength(255)]
        [Required]
        public string MobileNumber { get; set; }
    }
}
