using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class CreateMedicineDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
