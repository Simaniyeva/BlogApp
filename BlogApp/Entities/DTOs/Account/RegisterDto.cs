using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Account;

public class RegisterDto : IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
