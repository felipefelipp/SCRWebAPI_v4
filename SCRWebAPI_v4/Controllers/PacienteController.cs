using Api.Pagination;
using AutoMapper;
using Domain.AggregatesModel.Cliente;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Api.Models.Response;
using SCRWebAPI_v4.Domain.AggregatesModel.Parameters;
using SCRWebAPI_v4.Domain.Services;

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
    public async Task<ActionResult<ServiceResponse<PacienteResponse>>> ObterPaciente(int? id = null,
                                                                                    string? cpf = null,
                                                                                    string? nome = null,
                                                                                    DateTime? dataNascimento = null,
                                                                                    string? rg = null,
                                                                                    string? celular = null,
                                                                                    string? email = null,
                                                                                    string? telefone = null,
                                                                                    string? rua = null,
                                                                                    int? numero = null,
                                                                                    string? bairro = null,
                                                                                    string? municipio = null,
                                                                                    string? uf = null,
                                                                                    string? cep = null,
                                                                                    char? sexo = null,
                                                                                    string? profissao = null)
    {
        //_logger.LogInformation("-------------------- GET api/paciente/id ------------------");

        Paciente request = new Paciente
        {
            PacienteId = id,
            Nome = nome,
            DataNascimento = dataNascimento,
            CPF = cpf,
            RG = rg,
            Celular = celular,
            Email = email,
            Telefone = telefone,
            Rua = rua,
            Numero = numero,
            Bairro = bairro,
            Municipio = municipio,
            UF = uf,
            CEP = cep,
            Sexo = sexo,
            Profissao = profissao
        };

        var result = await _pacienteService.ObterPaciente(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        if (result.Data == null)
        {
            return NotFound();
        }

        var pacienteResponse = _mapper.Map<PacienteResponse>(result.Data);

        return Ok(new ServiceResponse<PacienteResponse>
        {
            Data = pacienteResponse,
            Success = true,
            Message = "Paciente encontrado"
        });
    }

    [HttpGet("/Pacientes")]
    public async Task<ActionResult<ServiceResponse<List<PacienteResponse>>>> ObterPacientes([FromQuery] Parameters pacienteParameters)
    {
        var parameters = _mapper.Map<ParametersQuery>(pacienteParameters);
        
        var result = await _pacienteService.ObterPacientes(parameters);
        
        var pacientes = _mapper.Map<List<PacienteResponse>>(result.Data);

        return Ok(new ServiceResponse<List<PacienteResponse>>
        {
            Data = pacientes,
            Success = true,
            Message = "Lista dos pacientes"
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPaciente(int id, [FromBody] PacienteRequest pacienteRequest)
    {
        var request = _mapper.Map<Paciente>(pacienteRequest);
        request.PacienteId = id;
        
        var result = await _pacienteService.AtualizarPaciente(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        var pacienteResponse = _mapper.Map<PacienteResponse>(result.Data);


        return Ok(new
        {
            Data = pacienteResponse,
            Success = true,
            Message = "Paciente atualizado com sucesso"
        });
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<PacienteResponse>>> AdicionarPaciente([FromBody] PacienteRequest pacienteRequest)
    {
        var request = _mapper.Map<Paciente>(pacienteRequest);

        var result = await _pacienteService.AdicionarPaciente(request);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        var pacienteResponse = _mapper.Map<PacienteResponse>(result.Data);

        return Ok(new ServiceResponse<PacienteResponse>
        {
            Data = pacienteResponse,
            Success = true,
            Message = "Paciente adicionado com sucesso"
        });
    }
}

