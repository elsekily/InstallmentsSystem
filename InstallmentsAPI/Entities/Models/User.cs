using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace InstallmentsAPI.Entities.Models;

public class User : IdentityUser<int>
{
    public ICollection<UserRole> Roles { get; set; }
}
