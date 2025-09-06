using System.Net;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Api.Common;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Cares.Commands;
using PatientManagement.Application.Cares.Queries;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Api.Controllers;

[ApiController]
[Route("api/v1/care")]
public class CareController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CareController> _logger;

    public CareController(IMediator mediator, ILogger<CareController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    
    [HttpGet("search")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<IEnumerable<CareDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<CareDto>))]
    public async Task<IActionResult> Search([FromQuery] SearchCareQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<CareDto>>.Ok(result.Data!));
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<CareDto>))]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetCareByIdQuery { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<CareDto>.Ok(result.Data!));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<CareDto>))]
    public async Task<IActionResult> Create([FromBody] CreateCareCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<CareDto>.Ok(result.Data!));
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<CareDto>))]
    public async Task<IActionResult> Update([FromBody] UpdateCareCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<CareDto>.Ok(result.Data!));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<CareDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<CareDto>))]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteCareCommand { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<CareDto>.Ok(result.Data!));
    }
}