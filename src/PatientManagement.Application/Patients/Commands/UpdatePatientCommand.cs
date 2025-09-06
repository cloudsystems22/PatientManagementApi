using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Enums;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Patients.Commands;

public class UpdatePatientCommand : ICommand<Result<PatientDto>>
{
    public string Id { get; set; }
    public string Rg { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Sex { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
}