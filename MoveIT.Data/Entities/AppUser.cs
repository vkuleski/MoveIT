using Microsoft.AspNetCore.Identity;

namespace MoveIT.Data.Entities;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}