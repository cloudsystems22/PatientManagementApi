using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class GetSpecialityByIdHandler : IQueryHandler<GetSpecialityByIdQuery, Result<SpecialityDto>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<GetSpecialityByIdHandler> _logger;

    public GetSpecialityByIdHandler(ISpecialityRepository repository, ILogger<GetSpecialityByIdHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<SpecialityDto>> Handle(GetSpecialityByIdQuery query)
    {
        _logger.LogInformation("[GetSpecialityByIdHandler] Iniciando retorno de especialidade: {Id}", query.Id);
        try
        {
            var speciality = await _repository.GetByIdAsync(query.Id);
            var dto = _mapper.ToDto(speciality);
            return Result<SpecialityDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar especialidade.");
            return Result<SpecialityDto>.Fail($"Erro ao pesquisar especialidade: {ex.Message}");
        }
    }
}