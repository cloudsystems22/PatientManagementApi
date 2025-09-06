using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Cares.Commands;

public class DeleteCareCommand : ICommand<Result<CareDto>>
{
    public string Id { get; set; }
}