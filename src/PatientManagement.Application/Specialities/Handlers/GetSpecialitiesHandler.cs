using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class GetSpecialitiesHandler : IQueryHandler<GetSpecialitiesQuery, Result<IEnumerable<SpecialityDto>>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<GetSpecialitiesHandler> _logger;

    public GetSpecialitiesHandler(ISpecialityRepository repository, ILogger<GetSpecialitiesHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

     public async Task<Result<IEnumerable<SpecialityDto>>> Handle(GetSpecialitiesQuery query)
    {
        _logger.LogInformation("[GetSpecialitiesHandler] Iniciando retorno de todas especialidades.");
        try
        {
            var specialities = await _repository.GetAllAsync();
            var dtos = _mapper.ToDtoIEnumerable(specialities);
            return Result<IEnumerable<SpecialityDto>>.Ok(dtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar especialidades.");
            return Result<IEnumerable<SpecialityDto>>.Fail($"Erro ao pesquisar especialidades: {ex.Message}");
        }
    }
}