using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Queries;

public class GetPatientByIdQuery : IQuery<Patient>
{
    public string Id { get; set; }
}