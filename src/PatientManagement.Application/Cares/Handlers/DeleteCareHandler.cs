using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Cares;

namespace PatientManagement.Application.Cares.Handlers;

public class DeleteCareHandler : ICommandHandler<DeleteCareCommand, Result<CareDto>>
{
    private readonly ICareRepository _repository;
    private readonly ICareMapper _mapper;
    private readonly ILogger<DeleteCareHandler> _logger;

    public DeleteCareHandler(ICareRepository repository, ILogger<DeleteCareHandler> logger, ICareMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<CareDto>> Handle(DeleteCareCommand command)
    {
        _logger.LogInformation("[DeleteCareHandler] Iniciando remoção de atendimento: {Id}", command.Id);
        try
        {
            var care = await _repository.GetByIdAsync(command.Id);
            if (care == null)
                return Result<CareDto>.Fail($"O atendimento com ID:{command.Id} não foi encontrado");

            await _repository.RemoveAsync(care);
            var dto = _mapper.ToDto(care);
            return Result<CareDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar apagar atendimento");
            return Result<CareDto>.Fail($"Erro ao tentar apagar atendimento: {ex.Message}");
        }
    }
}