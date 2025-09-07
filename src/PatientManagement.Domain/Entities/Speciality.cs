namespace PatientManagement.Domain.Entities;

public class Speciality
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Triage> Triagens { get; set; } = new List<Triage>();
}