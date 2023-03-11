using System.ComponentModel.DataAnnotations;

namespace AllergyCalendarAPI.Models;

public class UpdateDayDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public int MedicineId { get; set; }
    public List<int> SymptomIds { get; set; }
}
