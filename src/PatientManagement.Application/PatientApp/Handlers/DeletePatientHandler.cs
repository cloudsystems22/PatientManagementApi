using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class DeletePatientHandler : ICommandHandler<DeletePatientCommand, Result<Patient>>
{
    private readonly IPatientRepository _repository;
    private readonly ILogger<DeletePatientHandler> _logger;

    public DeletePatientHandler(IPatientRepository repository, ILogger<DeletePatientHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public async Task<Result<Patient>> Handle(DeletePatientCommand command)
    {
        _logger.LogInformation("[DeletePatientHandler] Iniciando remoção de paciente: {Id}", command.Id);
        try
        {
            var patient = await _repository.GetByIdAsync(command.Id);
            if (patient == null)
                return Result<Patient>.Fail($"O paciente desse ID:{command.Id}, não foi encontrado");

            await _repository.RemoveAsync(patient);
            return Result<Patient>.Ok(patient);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar paciente");
            return Result<Patient>.Fail($"Erro ao tentar apagar paciente: {ex.Message}");
        }
        
    }
}