using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Triages;

namespace PatientManagement.Application.Triages.Handlers;

public class GetTriageByIdHandler : IQueryHandler<GetTriageByIdQuery, Result<TriageDto>>
{
    private readonly ITriageRepository _repository;
    private readonly ITriageMapper _mapper;
    private readonly ILogger<GetTriageByIdHandler> _logger;

    public GetTriageByIdHandler(ITriageRepository repository, ILogger<GetTriageByIdHandler> logger, ITriageMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<TriageDto>> Handle(GetTriageByIdQuery query)
    {
        _logger.LogInformation("[GetTriageByIdHandler] Iniciando retorno de triagem: {Id}", query.Id);
        try
        {
            var triage = await _repository.GetByIdAsync(query.Id);
            var dto = _mapper.ToDto(triage);
            return Result<TriageDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar triagem.");
            return Result<TriageDto>.Fail($"Erro ao pesquisar triagem: {ex.Message}");
        }
    }
}