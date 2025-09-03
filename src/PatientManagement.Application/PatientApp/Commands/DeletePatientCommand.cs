using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Commands;

public class DeletePatientCommand : ICommand<bool>
{
    public string Id { get; set; }
}