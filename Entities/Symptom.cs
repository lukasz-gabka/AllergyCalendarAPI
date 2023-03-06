namespace AllergyCalendarAPI.Entities;

public class Symptom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Day> Days { get; set; }
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
}
