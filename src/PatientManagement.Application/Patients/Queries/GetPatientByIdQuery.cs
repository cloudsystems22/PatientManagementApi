using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Patients.Queries;

public class GetPatientByIdQuery : IQuery<Result<PatientDto>>
{
    public string Id { get; set; }
}