using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Triages.Queries;

public class SearchTriageQuery : IQuery<Result<IEnumerable<TriageDto>>>
{
    public string? CareId { get; set; }
    public string? Symptoms { get; set; }
    public string? SpecialtyId { get; set; }
}