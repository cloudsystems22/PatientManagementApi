using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Mappers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class DeletePatientHandler : ICommandHandler<DeletePatientCommand, Result<PatientDto>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<DeletePatientHandler> _logger;

    public DeletePatientHandler(IPatientRepository repository, ILogger<DeletePatientHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<Result<PatientDto>> Handle(DeletePatientCommand command)
    {
        _logger.LogInformation("[DeletePatientHandler] Iniciando remoção de paciente: {Id}", command.Id);
        try
        {
            var patient = await _repository.GetByIdAsync(command.Id);
            if (patient == null)
                return Result<PatientDto>.Fail($"O paciente desse ID:{command.Id}, não foi encontrado");

            await _repository.RemoveAsync(patient);
            var dto = _mapper.ToDto(patient);
            return Result<PatientDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar paciente");
            return Result<PatientDto>.Fail($"Erro ao tentar apagar paciente: {ex.Message}");
        }
        
    }
}