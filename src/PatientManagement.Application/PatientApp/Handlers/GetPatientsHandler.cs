using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Repositories;

namespace PatientManagement.Application.PatientApp.Handlers;

public class GetPatientsHandler
{
    private readonly IPatientRepository _repository;
    public GetPatientsHandler(IPatientRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Patient>> Handle(GetPatientsQuery query)
    {
        return await _repository.GetAllAsync();
    }
}