using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Queries;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Application.Mappers.Interfaces;
using PatientManagement.Domain.Interfaces.Repositories.Cares;

namespace PatientManagement.Application.Cares.Handlers;

public class GetCareByIdHandler : IQueryHandler<GetCareByIdQuery, Result<CareDto>>
{
    private readonly ICareRepository _repository;
    private readonly ICareMapper _mapper;
    private readonly ILogger<GetCareByIdHandler> _logger;

    public GetCareByIdHandler(ICareRepository repository, ILogger<GetCareByIdHandler> logger, ICareMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<CareDto>> Handle(GetCareByIdQuery query)
    {
        _logger.LogInformation("[GetCareByIdHandler] Iniciando retorno de atendimento: {Id}", query.Id);
        try
        {
            var care = await _repository.GetByIdAsync(query.Id);
            var dto = _mapper.ToDto(care);
            return Result<CareDto>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao pesquisar atendimento.");
            return Result<CareDto>.Fail($"Erro ao pesquisar atendimento: {ex.Message}");
        }
    }
}