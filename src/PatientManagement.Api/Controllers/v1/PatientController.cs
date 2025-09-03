using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Application.PatientApp.Queries;
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
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _mediator.Send(new GetPatientsQuery());
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var paciente = await _mediator.Send(new GetPatientByIdQuery { Id = id });
        if (paciente == null)
            return NotFound();
        return Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientCommand command)
    {
        var paciente = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id = paciente.Id }, paciente);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePatientCommand command)
    {
        if (string.IsNullOrEmpty(command.Id)) return BadRequest();

        var paciente = await _mediator.Send(command);
        if (paciente == null) return NotFound();

        return Ok(paciente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeletePatientCommand { Id = id });
        if (!result) return NotFound();
        return NoContent();
    }

}