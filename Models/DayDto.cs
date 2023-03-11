using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class DayDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public virtual MedicineDto? Medicine { get; set; }
    public List<SymptomDto> Symptoms { get; set; }
}
