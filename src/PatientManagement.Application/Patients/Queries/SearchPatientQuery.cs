using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Patients.Queries;

public class SearchPatientsQuery : IQuery<Result<IEnumerable<PatientDto>>>
{
    public string? Rg { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? EmailAddress { get; set; }
}
