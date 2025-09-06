using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Cares;

namespace PatientManagement.Application.Cares.Handlers;

public class UpdateCareHandler : ICommandHandler<UpdateCareCommand, Result<CareDto>>
{
    private readonly ICareRepository _repository;
    private readonly ICareMapper _mapper;
    private readonly ILogger<UpdateCareHandler> _logger;

    public UpdateCareHandler(ICareRepository repository, ILogger<UpdateCareHandler> logger, ICareMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<CareDto>> Handle(UpdateCareCommand command)
    {
        try
        {
            var care = await _repository.GetByIdAsync(command.Id);

            if (care == null)
                return Result<CareDto>.Ok(new CareDto());

            care.SequenceNumber = command.SequenceNumber;
            care.PatientId = command.PatientId;
            care.ArrivalTime = command.ArrivalTime;
            care.Status = command.Status;

            await _repository.UpdateAsync(care);
            var dto = _mapper.ToDto(care);
            return Result<CareDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar atualizar dados do atendimento.");
            return Result<CareDto>.Fail($"Erro ao tentar atualizar dados do atendimento. {ex.Message}");
        }
    }
}