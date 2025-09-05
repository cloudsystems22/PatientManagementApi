using PatientManagement.Application.Common;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Commands;

public class DeletePatientCommand : ICommand<Result<Patient>>
{
    public string Id { get; set; }
}