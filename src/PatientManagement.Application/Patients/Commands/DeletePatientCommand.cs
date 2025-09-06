using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Patients.Commands;

public class DeletePatientCommand : ICommand<Result<PatientDto>>
{
    public string Id { get; set; }
}