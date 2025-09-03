namespace PatientManagement.Domain.Entities;

public class Triage
{
    public int Id { get; set; }
    public int CareId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public int SpecialtyId { get; set; }

    public Care Care { get; set; } = null!;
    public Specialty Specialty { get; set; } = null!;
}