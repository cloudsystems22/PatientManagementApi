using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;


namespace PatientManagement.Application.PatientApp.Handlers;

public class GetPatientByIdHandler : IQueryHandler<GetPatientByIdQuery, Patient>
{
    private readonly IPatientRepository _repository;
    public GetPatientByIdHandler(IPatientRepository repository)
        => _repository = repository;
   
    public async Task<Patient> Handle(GetPatientByIdQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}