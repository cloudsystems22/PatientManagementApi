using PatientManagement.Domain.Enums;
namespace PatientManagement.Domain.Entities;

public class Care
{
    public int Id { get; set; }
    public int SequenceNumber { get; set; }
    public string PatientId { get; set; }
    public DateTime ArrivalTime { get; set; } = DateTime.Now;
    public StatusCare Status { get; set; } = StatusCare.Aguardando;
    public Patient Patient { get; set; } = null!;
    public Triage? Triage { get; set; }
}