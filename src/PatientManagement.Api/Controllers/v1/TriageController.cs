using System.Net;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Api.Common;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Triages.Commands;
using PatientManagement.Application.Triages.Queries;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Api.Controllers.v1;

[ApiController]
[Route("api/v1/triage")]
public class TriageController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TriageController> _logger;

    public TriageController(IMediator mediator, ILogger<TriageController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("search")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<IEnumerable<TriageDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<TriageDto>))]
    public async Task<IActionResult> Search([FromQuery] SearchTriageQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<TriageDto>>.Ok(result.Data!));
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<TriageDto>))]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetTriageByIdQuery { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<TriageDto>.Ok(result.Data!));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<TriageDto>))]
    public async Task<IActionResult> Create([FromBody] CreateTriageCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<TriageDto>.Ok(result.Data!));
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<TriageDto>))]
    public async Task<IActionResult> Update([FromBody] UpdateTriageCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<TriageDto>.Ok(result.Data!));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<TriageDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<TriageDto>))]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteTriageCommand { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<TriageDto>.Ok(result.Data!));
    }
}