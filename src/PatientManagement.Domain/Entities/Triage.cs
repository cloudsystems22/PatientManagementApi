namespace PatientManagement.Domain.Entities;

public class Triage
{
    public string Id { get; set; }
    public string CareId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string SpecialtyId { get; set; }

    public Care Care { get; set; } = null!;
    public Speciality Specialty { get; set; } = null!;
}