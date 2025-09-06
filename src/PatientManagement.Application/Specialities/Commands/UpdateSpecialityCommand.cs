using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Specialities.Commands;

public class UpdateSpecialityCommand : ICommand<Result<SpecialityDto>>
{
    public string Id { get; set; }
    public string Name { get; set; }
}