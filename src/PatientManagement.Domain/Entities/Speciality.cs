namespace PatientManagement.Domain.Entities;

public class Specialty
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Triage> Triagens { get; set; } = new List<Triage>();
}