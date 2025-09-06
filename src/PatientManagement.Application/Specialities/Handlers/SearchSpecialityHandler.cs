using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Specialities;

namespace PatientManagement.Application.Specialities.Handlers;

public class SearchSpecialityHandler : IQueryHandler<SearchSpecialityQuery, Result<IEnumerable<SpecialityDto>>>
{
    private readonly ISpecialityRepository _repository;
    private readonly ISpecialityMapper _mapper;
    private readonly ILogger<SearchSpecialityHandler> _logger;

    public SearchSpecialityHandler(ISpecialityRepository repository, ILogger<SearchSpecialityHandler> logger, ISpecialityMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<SpecialityDto>>> Handle(SearchSpecialityQuery query)
    {
        _logger.LogInformation("[SearchSpecialityHandler] Iniciando retorno filtrado de especialidades.");
        try
        {
            Expression<Func<Speciality, bool>> filter = x =>
                string.IsNullOrEmpty(query.Name) || x.Name.Contains(query.Name);

            _logger.LogInformation("[SearchSpecialityHandler] Filtro executado. {filter}", filter);
            var result = await _repository.GetAllWhereAsync(filter);
            var dto = _mapper.ToDtoIEnumerable(result);
            return Result<IEnumerable<SpecialityDto>>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de especialidades");
            return Result<IEnumerable<SpecialityDto>>.Fail($"Erro ao tentar retornar uma lista de especialidades: {ex.Message}");
        }
    }
}