namespace AllergyCalendarAPI.Entities;

public class Day
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int MedicineId { get; set; }
    public virtual Medicine Medicine { get; set; }
    public List<Symptom> Symptoms { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}
