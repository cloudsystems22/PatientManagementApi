namespace PatientManagement.Application.Dtos;

public class TriageDto
{
    public int Id { get; set; }
    public int CareId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public int SpecialtyId { get; set; }
}