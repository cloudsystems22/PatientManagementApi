using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Triages.Queries;

public class GetTriageByIdQuery : IQuery<Result<TriageDto>>
{
    public string Id { get; set; } = string.Empty;
}