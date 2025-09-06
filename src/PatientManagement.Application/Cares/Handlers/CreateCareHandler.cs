using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Cares;

namespace PatientManagement.Application.Cares.Handlers;

public class CreateCareHandler : ICommandHandler<CreateCareCommand, Result<CareDto>>
{
    private readonly ICareRepository _repository;
    private readonly ICareMapper _mapper;
    private readonly ILogger<CreateCareHandler> _logger;

    public CreateCareHandler(ICareRepository repository, ILogger<CreateCareHandler> logger, ICareMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<CareDto>> Handle(CreateCareCommand command)
    {
        _logger.LogInformation("[CreateCareHandler] Iniciando criação de atendimento: {SequenceNumber}", command.SequenceNumber);
        try
        {
            var entity = _mapper.ToEntity(command);
            await _repository.AddAsync(entity);
            var dto = _mapper.ToDto(entity);
            return Result<CareDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar atendimento");
            return Result<CareDto>.Fail($"Erro ao cadastrar atendimento: {ex.Message}");
        }
    }
}