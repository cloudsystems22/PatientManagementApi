using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Triages.Commands;

public class CreateTriageCommand : ICommand<Result<TriageDto>>
{
    public string Id { get; set; }
    public string CareId { get; set; }
    public string Symptoms { get; set; } = string.Empty;
    public string BloodPressure { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public string SpecialtyId { get; set; }
}