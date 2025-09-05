using PatientManagement.Application.Common;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Commands;

public class UpdatePatientCommand : ICommand<Result<Patient>>
{
    public string Id { get; set; }
    public string Rg { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}