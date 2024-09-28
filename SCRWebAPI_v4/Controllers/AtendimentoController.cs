using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _atendimentoService;
        public AtendimentoController(IAtendimentoService atendimentoService)
        {
           _atendimentoService = atendimentoService;
        }


        [HttpGet("/Atendimento")]
        public async Task<IActionResult> ObterAtendimentoPorIdAsync(int idAtendimento)
        {
            var result = await _atendimentoService.ObterAtendimentoPorIdAsync(idAtendimento);

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

        [HttpGet("/Atendimentos/Paciente")]
        public async Task<IActionResult> ObterAtendimentosPorIdPacienteAsync(int idPaciente)
        {
            var result = await  _atendimentoService.ObterAtendimentosPacienteAsync(idPaciente);

            return Ok(result);
        }

        [HttpGet("/Atendimentos")]
        public async Task<IActionResult> ObterAtendimentosAsync([FromQuery] int pageNumber, int pageSize)
        {
            var result = await _atendimentoService.ObterAtendimentosAsync(pageNumber, pageSize);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarAtendimentoAsync(AtendimentoDto atendimentoDto)
        {

            var result = await _atendimentoService.AdicionarAtendimentoAsync(atendimentoDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
            
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarIdPacienteAtendimentoAsync(int atendimentoPacienteId, int pacienteId)
        {
            var result = await _atendimentoService.AtualizarIdPacienteAtendimentoAsync(atendimentoPacienteId, pacienteId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
