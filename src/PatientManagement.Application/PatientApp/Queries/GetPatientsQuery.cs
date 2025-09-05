using PatientManagement.Application.Common;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Application.PatientApp.Queries;

public class GetPatientsQuery : IQuery<Result<IEnumerable<Patient>>> {}