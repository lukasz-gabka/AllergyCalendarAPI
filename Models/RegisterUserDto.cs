using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class RegisterUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(8)]
    public string Password { get; set; }
    [Required]
    [MinLength(8)]
    public string ConfirmPassword { get; set; }

}
