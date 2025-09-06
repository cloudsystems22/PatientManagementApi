using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class DeleteSpecialityHandler : ICommandHandler<DeleteSpecialityCommand, Result<SpecialityDto>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<DeleteSpecialityHandler> _logger;

    public DeleteSpecialityHandler(ISpecialityRepository repository, ILogger<DeleteSpecialityHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<SpecialityDto>> Handle(DeleteSpecialityCommand command)
    {
        _logger.LogInformation("[DeleteSpecialityHandler] Iniciando remoção de especialidade: {Id}", command.Id);
        try
        {
            var speciality = await _repository.GetByIdAsync(command.Id);
            if (speciality == null)
                return Result<SpecialityDto>.Fail($"A especialidade desse ID:{command.Id}, não foi encontrada");

            await _repository.RemoveAsync(speciality);
            var dto = _mapper.ToDto(speciality);
            return Result<SpecialityDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar apagar especialidade");
            return Result<SpecialityDto>.Fail($"Erro ao tentar apagar especialidade: {ex.Message}");
        }
    }
}