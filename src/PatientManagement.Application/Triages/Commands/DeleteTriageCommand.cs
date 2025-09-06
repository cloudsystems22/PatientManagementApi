using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Triages.Commands;

public class DeleteTriageCommand : ICommand<Result<TriageDto>>
{
    public string Id { get; set; }
}