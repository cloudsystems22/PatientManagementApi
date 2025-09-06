using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Triages;

namespace PatientManagement.Application.Triages.Handlers;

public class SearchTriageHandler : IQueryHandler<SearchTriageQuery, Result<IEnumerable<TriageDto>>>
{
    private readonly ITriageRepository _repository;
    private readonly ITriageMapper _mapper;
    private readonly ILogger<SearchTriageHandler> _logger;

    public SearchTriageHandler(ITriageRepository repository, ILogger<SearchTriageHandler> logger, ITriageMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<TriageDto>>> Handle(SearchTriageQuery query)
    {
        _logger.LogInformation("[SearchTriageHandler] Iniciando retorno filtrado de triagens.");
        try
        {
            Expression<Func<Triage, bool>> filter = x =>
                (string.IsNullOrEmpty(query.CareId) || x.CareId == query.CareId) &&
                (string.IsNullOrEmpty(query.Symptoms) || x.Symptoms.Contains(query.Symptoms)) &&
                (string.IsNullOrEmpty(query.SpecialtyId) || x.SpecialtyId == query.SpecialtyId);

            var result = await _repository.GetAllWhereAsync(filter);
            var dto = _mapper.ToDtoIEnumerable(result);
            return Result<IEnumerable<TriageDto>>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de triagens");
            return Result<IEnumerable<TriageDto>>.Fail($"Erro ao tentar retornar uma lista de triagens: {ex.Message}");
        }
    }
}