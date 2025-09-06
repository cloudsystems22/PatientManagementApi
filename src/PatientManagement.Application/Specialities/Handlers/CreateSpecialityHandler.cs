using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class CreateSpecialityHandler : ICommandHandler<CreateSpecialityCommand, Result<SpecialityDto>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<CreateSpecialityHandler> _logger;

    public CreateSpecialityHandler(ISpecialityRepository repository, ILogger<CreateSpecialityHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<SpecialityDto>> Handle(CreateSpecialityCommand command)
    {
        _logger.LogInformation("[CreateSpecialityHandler] Iniciando criação de especialidade: {Name}", command.Name);
        try
        {
            var entity = _mapper.ToEntity(command);
            await _repository.AddAsync(entity);
            var dto = _mapper.ToDto(entity);
            return Result<SpecialityDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar especialidade");
            return Result<SpecialityDto>.Fail($"Erro ao cadastrar especialidade: {ex.Message}");
        }
    }
}