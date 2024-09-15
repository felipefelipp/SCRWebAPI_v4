using AutoMapper;
using Domain.AggregatesModel.Cliente;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Api.Models.Request;
using SCRWebAPI_v4.Api.Models.Response;
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

    [HttpGet("/paciente/{id}")]
    //[ServiceFilter(typeof(ApiLoggingFilter))]
    public async Task<IActionResult> ObterPacientePorId(int id)
    {
        //_logger.LogInformation("-------------------- GET api/paciente/id ------------------");
        var paciente = await _pacienteService.ObterPacienteById(id);
        if (paciente == null)
        {
            return NotFound();
        }
        return Ok(paciente);
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
//    public async Task<ActionResult<IEnumerable<PacienteDTO>>> ObterPacientes([FromQuery] Parameters pacienteParameters)
//    {
//        _logger.LogInformation("-------------------- GET api/Paciente ------------------");

//        var pacientes = await _unitOfWork.PacienteRepository.GetAll(pacienteParameters);

//        var metadata = new
//        {
//            pacientes.TotalItemCount,
//            pacientes.PageSize,
//            pacientes.PageCount,
//            pacientes.PageNumber,
//            pacientes.Count,
//            pacientes.HasNextPage,
//            pacientes.HasPreviousPage,
//            pacientes.IsFirstPage,
//            pacientes.IsLastPage
//        };

//        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

//        if (pacientes == null)
//            return NotFound($"Pacientes não encontrados");

//        var pacientesDTO = _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);

//        return Ok(pacientesDTO);
//    }

//    [HttpGet("{id:int}", Name = "ObterPaciente")]
//    public async Task<ActionResult<PacienteDTO>> ObterPaciente(int id)
//    {

//        _logger.LogInformation($"-------------------- GET api/Paciente/id: {id} ------------------");

//        var paciente = await _unitOfWork.PacienteRepository.Get(p => p.PacienteId == id);

//        if (paciente == null)
//            return NotFound($"Paciente com id {id} não encontrado");

//        var pacienteDTO = _mapper.Map<PacienteDTO>(paciente);

//        return Ok(pacienteDTO);
//    }



//    [HttpPut("{id:int}")]
//    public async Task<ActionResult<PacienteDTO>> AtualizarPaciente(int id, PacienteDTO pacienteDto)
//    {
//        if (id != pacienteDto.PacienteId)
//            return BadRequest($"Id inválido");

//        var paciente = _mapper.Map<Paciente>(pacienteDto);

//        var pacienteAtualizado = _unitOfWork.PacienteRepository.Update(paciente);
//        await _unitOfWork.Commit();

//        var pacienteAtualizadoDto = _mapper.Map<PacienteDTO>(pacienteAtualizado);

//        return Ok(pacienteAtualizadoDto);
//    }

//    [HttpDelete("{id:int}")]
//    public async Task<ActionResult<PacienteDTO>> DeletarPaciente(int id)
//    {
//        var paciente = await _unitOfWork.PacienteRepository.Get(p => p.PacienteId == id);
//        if (paciente == null)
//            return BadRequest($"Paciente não encontrado!");

//        var pacienteDeletado = _unitOfWork.PacienteRepository.Delete(paciente);
//        await _unitOfWork.Commit();

//        var pacienteDeletadoDto = _mapper.Map<PacienteDTO>(pacienteDeletado);

//        return Ok(pacienteDeletadoDto);
//    }
//}
