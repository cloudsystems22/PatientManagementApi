using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.Patients.Queries;

public class GetPatientsQuery : IQuery<Result<IEnumerable<PatientDto>>> {}