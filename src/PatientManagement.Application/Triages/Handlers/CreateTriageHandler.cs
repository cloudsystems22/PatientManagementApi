using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Triages;

namespace PatientManagement.Application.Triages.Handlers;

public class CreateTriageHandler : ICommandHandler<CreateTriageCommand, Result<TriageDto>>
{
    private readonly ITriageRepository _repository;
    private readonly ITriageMapper _mapper;
    private readonly ILogger<CreateTriageHandler> _logger;

    public CreateTriageHandler(ITriageRepository repository, ILogger<CreateTriageHandler> logger, ITriageMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<TriageDto>> Handle(CreateTriageCommand command)
    {
        _logger.LogInformation("[CreateTriageHandler] Iniciando criação de triagem: {CareId}", command.CareId);
        try
        {
            var entity = _mapper.ToEntity(command);
            await _repository.AddAsync(entity);
            var dto = _mapper.ToDto(entity);
            return Result<TriageDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar triagem");
            return Result<TriageDto>.Fail($"Erro ao cadastrar triagem: {ex.Message}");
        }
    }
}