using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Cares.Queries;

public class GetCaresQuery : IQuery<Result<IEnumerable<CareDto>>>
{
}