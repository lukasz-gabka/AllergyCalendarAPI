namespace AllergyCalendarAPI.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string PasswordHash { get; set; }
    public virtual List<Day> Days { get; set; }
    public virtual List<Medicine> Medicines { get; set; }
    public virtual List<Symptom> Symptoms { get; set; }
}
