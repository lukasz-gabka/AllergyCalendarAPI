using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Entities;

public class RegisterUserDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }

}
