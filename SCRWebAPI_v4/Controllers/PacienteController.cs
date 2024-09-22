using AutoMapper;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Controllers;

[Route("[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IPacienteService _pacienteService;
    private readonly IMapper _mapper;
    public PacienteController(ILogger<PacienteController> logger,
                              IPacienteService pacienteService,
                              IMapper mapper)
    {
        _logger = logger;
        _pacienteService = pacienteService;
        _mapper = mapper;
    }

    [HttpGet]
    //[ServiceFilter(typeof(ApiLoggingFilter))]
    public async Task<IActionResult> ObterPaciente(int? id = null, 
                                                   string? cpf = null,
                                                   string? rg = null,
                                                   string? celular = null,
                                                   string? email = null,
                                                   string? telefone = null)
    {
        //_logger.LogInformation("-------------------- GET api/paciente/id ------------------");


        var result = await _pacienteService.ObterPaciente(id, cpf, rg, celular, email, telefone);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        if (result.Data == null)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpGet("/Pacientes")]
    public async Task<IActionResult> ObterPacientes([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var result = await _pacienteService.ObterPacientes(pageNumber, pageSize);
 
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] PacienteDto pacienteRequest)
    {
        
        var result = await _pacienteService.AtualizarPaciente(id, pacienteRequest);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarPaciente([FromBody] PacienteDto pacienteRequest)
    {
        var result = await _pacienteService.AdicionarPaciente(pacienteRequest);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}

