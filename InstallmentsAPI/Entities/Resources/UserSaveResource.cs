using System.ComponentModel.DataAnnotations;


namespace InstallmentsAPI.Entities.Resources;
public class UserSaveResource
{
    [Required]
    public string Email { get; set; }
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}