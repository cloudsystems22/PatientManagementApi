using System.Net;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Api.Common;
using PatientManagement.Application.Common;
using PatientManagement.Application.Dtos;
using PatientManagement.Application.Specialities.Commands;
using PatientManagement.Application.Specialities.Queries;
using PatientManagement.Domain.Interfaces.Mediator;

namespace PatientManagement.Api.Controllers;

[ApiController]
[Route("api/v1/speciality")]
public class SpecialityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SpecialityController> _logger;

    public SpecialityController(IMediator mediator, ILogger<SpecialityController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<IEnumerable<SpecialityDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<IEnumerable<SpecialityDto>>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<IEnumerable<SpecialityDto>>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetSpecialitiesQuery());
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<SpecialityDto>>.Ok(result.Data!));
    }

    [HttpGet("search")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<IEnumerable<SpecialityDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<SpecialityDto>))]
    public async Task<IActionResult> Search([FromQuery] SearchSpecialityQuery query)
    {
        var result = await _mediator.Send(query);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<IEnumerable<SpecialityDto>>.Ok(result.Data!));
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<SpecialityDto>))]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _mediator.Send(new GetSpecialityByIdQuery { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<SpecialityDto>.Ok(result.Data!));
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<SpecialityDto>))]
    public async Task<IActionResult> Create([FromBody] CreateSpecialityCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<SpecialityDto>.Ok(result.Data!));
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<SpecialityDto>))]
    public async Task<IActionResult> Update([FromBody] UpdateSpecialityCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<SpecialityDto>.Ok(result.Data!));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Result<SpecialityDto>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(Result<SpecialityDto>))]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteSpecialityCommand { Id = id });
        if (!result.Success)
            return BadRequest(ApiResponse<string>.Fail(result.Error!));

        return Ok(ApiResponse<SpecialityDto>.Ok(result.Data!));
    }
}