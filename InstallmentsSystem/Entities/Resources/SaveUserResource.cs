using System.ComponentModel.DataAnnotations;

namespace InstallmentsSystem.Entities.Resources
{
    public class SaveUserResource
    {
        [Required]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
