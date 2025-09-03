using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.PatientApp.Commands;
using PatientManagement.Application.PatientApp.Handlers;
using PatientManagement.Application.PatientApp.Queries;

namespace PatientManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly CreatePatientHandler _createHandler;
    private readonly GetPatientsHandler _getHandler;

    public PatientController(CreatePatientHandler createHandler,
                             GetPatientsHandler getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pacientes = await _getHandler.Handle(new GetPatientsQuery());
        return Ok(pacientes);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePatientCommand command)
    {
        var paciente = await _createHandler.Handle(command);
        return CreatedAtAction(nameof(GetAll), new { id = paciente.Id }, paciente);
    }

}