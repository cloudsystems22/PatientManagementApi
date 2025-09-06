using System.Net;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Api.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Application.PatientApp.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Api.Controllers;

[ApiController]
[Route("api/v1/patient")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PatientController> _logger;

    public PatientController(IMediator mediator, ILogger<PatientController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PatientDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetPatientsQuery());
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<PatientDto>>.Ok(result.Data!));
    }

    [HttpGet("search")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PatientDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> Search([FromQuery] SearchPatientsQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<PatientDto>>.Ok(result.Data!));
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PatientDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetPatientByIdQuery { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<PatientDto>.Ok(result.Data!));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PatientDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> Create([FromBody] CreatePatientCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<PatientDto>.Ok(result.Data!));
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PatientDto))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> Update([FromBody] UpdatePatientCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<PatientDto>.Ok(result.Data!));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Error))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Error))]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeletePatientCommand { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<PatientDto>.Ok(result.Data!));
    }

}