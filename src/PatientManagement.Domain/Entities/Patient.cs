namespace PatientManagement.Domain.Entities;

public class Patient
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string EmailAdress { get; set; } = string.Empty;

    public ICollection<Care> Cares { get; set; } = new List<Care>();
}