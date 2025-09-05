using PatientManagement.Application.Common;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Queries;

public class SearchPatientsQuery : IQuery<Result<IEnumerable<Patient>>>
{
    public string? Rg { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? EmailAddress { get; set; }
}
