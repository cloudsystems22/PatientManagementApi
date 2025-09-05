using PatientManagement.Application.Common;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Queries;

public class GetPatientByIdQuery : IQuery<Result<Patient>>
{
    public string Id { get; set; }
}