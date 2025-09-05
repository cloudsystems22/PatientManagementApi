using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class GetPatientsHandler : IQueryHandler<GetPatientsQuery, Result<IEnumerable<Patient>>>
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<GetPatientsHandler> _logger;
    public GetPatientsHandler(IPatientRepository repository, ILogger<GetPatientsHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    public async Task<Result<IEnumerable<Patient>>> Handle(GetPatientsQuery query)
    {
        _logger.LogInformation("[GetPatientsHandler] Iniciando retorno de pacientes.");
        try
        {
            var pacientes = await _repository.GetAllAsync();
            return Result<IEnumerable<Patient>>.Ok(pacientes.ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de pacientes");
            return Result<IEnumerable<Patient>>.Fail($"Erro ao tentar retornar uma lista de pacientes: {ex.Message}");
        }
    }

}