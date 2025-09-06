using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Specialities.Queries;

public class SearchSpecialityQuery : IQuery<Result<IEnumerable<SpecialityDto>>>
{
    public string? Name { get; set; }
}