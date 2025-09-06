using PatientManagement.Domain.Enums;

namespace PatientManagement.Application.Dtos;

public class CareDto
{
    public int Id { get; set; }
    public int SequenceNumber { get; set; }
    public string PatientId { get; set; }
    public DateTime ArrivalTime { get; set; }
    public StatusCare Status { get; set; }
}