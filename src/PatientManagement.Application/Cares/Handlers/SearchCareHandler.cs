using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Cares;

namespace PatientManagement.Application.Cares.Handlers;

public class SearchCareHandler : IQueryHandler<SearchCareQuery, Result<IEnumerable<CareDto>>>
{
    private readonly ICareRepository _repository;
    private readonly ICareMapper _mapper;
    private readonly ILogger<SearchCareHandler> _logger;

    public SearchCareHandler(ICareRepository repository, ILogger<SearchCareHandler> logger, ICareMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<CareDto>>> Handle(SearchCareQuery query)
    {
        _logger.LogInformation("[SearchCareHandler] Iniciando retorno filtrado de atendimentos.");
        try
        {
            Expression<Func<Care, bool>> filter = x =>
                (string.IsNullOrEmpty(query.SequenceNumber) || x.SequenceNumber.Contains(query.SequenceNumber)) &&
                (string.IsNullOrEmpty(query.PatientId) || x.PatientId == query.PatientId) &&
                (!query.ArrivalTime.HasValue || x.ArrivalTime.Date == query.ArrivalTime.Value.Date) &&
                (!query.Status.HasValue || x.Status == query.Status.Value);

            var result = await _repository.GetAllWhereAsync(filter);
            var dto = _mapper.ToDtoIEnumerable(result);
            return Result<IEnumerable<CareDto>>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de atendimentos");
            return Result<IEnumerable<CareDto>>.Fail($"Erro ao tentar retornar uma lista de atendimentos: {ex.Message}");
        }
    }
}