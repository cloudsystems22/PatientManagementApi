using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Enums;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Cares.Commands;

public class UpdateCareCommand : ICommand<Result<CareDto>>
{
    public string Id { get; set; }
    public string SequenceNumber { get; set; }
    public string PatientId { get; set; }
    public DateTime ArrivalTime { get; set; }
    public StatusCare Status { get; set; }
}