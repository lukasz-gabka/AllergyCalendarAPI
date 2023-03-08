using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class MedicineDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
