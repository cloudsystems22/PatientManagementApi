using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class UpdateSpecialityHandler : ICommandHandler<UpdateSpecialityCommand, Result<SpecialityDto>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<UpdateSpecialityHandler> _logger;

    public UpdateSpecialityHandler(ISpecialityRepository repository, ILogger<UpdateSpecialityHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<SpecialityDto>> Handle(UpdateSpecialityCommand command)
    {
        _logger.LogInformation("[UpdateSpecialityHandler] Iniciando atualização de especialidade: {Id}", command.Id);
        try
        {
            var speciality = await _repository.GetByIdAsync(command.Id);

            if (speciality == null)
                return Result<SpecialityDto>.Ok(new SpecialityDto());

            speciality.Name = command.Name;

            await _repository.UpdateAsync(speciality);
            var dto = _mapper.ToDto(speciality);
            return Result<SpecialityDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar atualizar dados de especialidade.");
            return Result<SpecialityDto>.Fail($"Erro ao tentar atualizar dados de especialidade. {ex.Message}");
        }
    }
}