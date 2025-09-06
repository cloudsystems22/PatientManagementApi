using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Triages;

namespace PatientManagement.Application.Triages.Handlers;

public class DeleteTriageHandler : ICommandHandler<DeleteTriageCommand, Result<TriageDto>>
{
    private readonly ITriageRepository _repository;
    private readonly ITriageMapper _mapper;
    private readonly ILogger<DeleteTriageHandler> _logger;

    public DeleteTriageHandler(ITriageRepository repository, ILogger<DeleteTriageHandler> logger, ITriageMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<TriageDto>> Handle(DeleteTriageCommand command)
    {
        _logger.LogInformation("[DeleteTriageHandler] Iniciando remoção de triagem: {Id}", command.Id);
        try
        {
            var triage = await _repository.GetByIdAsync(command.Id);
            if (triage == null)
                return Result<TriageDto>.Fail($"A triagem com ID:{command.Id} não foi encontrada.");

            await _repository.RemoveAsync(triage);
            var dto = _mapper.ToDto(triage);
            return Result<TriageDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar apagar triagem.");
            return Result<TriageDto>.Fail($"Erro ao tentar apagar triagem: {ex.Message}");
        }
    }
}