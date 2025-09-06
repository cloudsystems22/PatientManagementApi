using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Cares.Commands;

public class CreateCareCommand : ICommand<Result<CareDto>>
{
    public string Id { get; set; }
    public string SequenceNumber { get; set; }
    public string PatientId { get; set; } = string.Empty;
    public DateTime ArrivalTime { get; set; }
    public PatientManagement.Domain.Enums.StatusCare Status { get; set; }
}