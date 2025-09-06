using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Specialities.Queries;

public class GetSpecialityByIdQuery : IQuery<Result<SpecialityDto>>
{
    public string Id { get; set; }
}