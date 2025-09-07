using PatientManagement.Domain.Enums;

namespace PatientManagement.Domain.Entities;

public class Patient
{
    public string Id { get; set; } = null!;
    public string Rg { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Gender Sex { get; set; }
    public string EmailAddress { get; set; } = null!;

    public ICollection<Care> Cares { get; set; } = new List<Care>();
}