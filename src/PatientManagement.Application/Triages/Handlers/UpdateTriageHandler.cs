using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Triages;

namespace PatientManagement.Application.Triages.Handlers;

public class UpdateTriageHandler : ICommandHandler<UpdateTriageCommand, Result<TriageDto>>
{
    private readonly ITriageRepository _repository;
    private readonly ITriageMapper _mapper;
    private readonly ILogger<UpdateTriageHandler> _logger;

    public UpdateTriageHandler(ITriageRepository repository, ILogger<UpdateTriageHandler> logger, ITriageMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<TriageDto>> Handle(UpdateTriageCommand command)
    {
        _logger.LogInformation("[UpdateTriageHandler] Iniciando atualização de triagem: {Id}", command.Id);
        try
        {
            var triage = await _repository.GetByIdAsync(command.Id);

            if (triage == null)
                return Result<TriageDto>.Fail($"A triagem com ID:{command.Id} não foi encontrada.");

            triage.Symptoms = command.Symptoms;
            triage.BloodPressure = command.BloodPressure;
            triage.Height = command.Height;
            triage.Weight = command.Weight;
            
            await _repository.UpdateAsync(triage);
            var dto = _mapper.ToDto(triage);
            return Result<TriageDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar atualizar dados da triagem.");
            return Result<TriageDto>.Fail($"Erro ao tentar atualizar dados da triagem. {ex.Message}");
        }
    }
}