using PatientManagement.Domain.Enums;

namespace PatientManagement.Domain.Entities;

public class Patient
{
    public string Id { get; set; }
    public string Rg { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Sex { get; set; }
    public string EmailAddress { get; set; } = string.Empty;

    public ICollection<Care> Cares { get; set; } = new List<Care>();
}