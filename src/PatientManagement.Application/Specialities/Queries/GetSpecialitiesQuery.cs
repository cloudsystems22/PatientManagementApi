using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Specialities.Queries;

public class GetSpecialitiesQuery : IQuery<Result<IEnumerable<SpecialityDto>>>
{
}