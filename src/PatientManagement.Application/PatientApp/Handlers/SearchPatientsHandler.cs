using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Handlers;
using PatientManagement.Domain.Interfaces.Mappers;
using PatientManagement.Domain.Interfaces.Repositories.Patients;

namespace PatientManagement.Application.PatientApp.Handlers;

public class SearchPatientsHandler : IQueryHandler<SearchPatientsQuery, Result<IEnumerable<PatientDto>>>
{
    private readonly IPatientRepository _repository;
    private readonly IPatientMapper _mapper;
    private readonly ILogger<SearchPatientsHandler> _logger;

    public SearchPatientsHandler(IPatientRepository repository, ILogger<SearchPatientsHandler> logger, IPatientMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<PatientDto>>> Handle(SearchPatientsQuery query)
    {
        _logger.LogInformation("[SearchPatientsHandler] Iniciando retorno filtrado de pacientes.");
        try
        {
            Expression<Func<Patient, bool>> filter = x =>
            (string.IsNullOrEmpty(query.Rg) || x.Rg.Contains(query.Rg)) &&
            (string.IsNullOrEmpty(query.Name) || x.Name.Contains(query.Name)) &&
            (string.IsNullOrEmpty(query.Phone) || x.Phone.Contains(query.Phone)) &&
            (string.IsNullOrEmpty(query.EmailAddress) || x.EmailAddress.Contains(query.EmailAddress));

            _logger.LogInformation("[SearchPatientsHandler] Filtro executado. {filter}", filter);
            var result = await _repository.GetAllWhereAsync(filter);
            var dto = _mapper.ToDtoIEnumerable(result);
            return Result<IEnumerable<PatientDto>>.Ok(dto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao tentar retornar uma lista de pacientes");
            return Result<IEnumerable<PatientDto>>.Fail($"Erro ao tentar retornar uma lista de pacientes: {ex.Message}");
        }
    }

}
