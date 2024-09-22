using AutoMapper;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Controllers;

[Route("[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    public PacienteController(IPacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterPaciente(int? id = null, 
                                                   string? cpf = null,
                                                   string? rg = null,
                                                   string? celular = null,
                                                   string? email = null,
                                                   string? telefone = null)
    {

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

