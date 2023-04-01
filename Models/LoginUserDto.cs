using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
}
