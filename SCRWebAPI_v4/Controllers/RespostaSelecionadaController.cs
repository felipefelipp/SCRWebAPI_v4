using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RespostaSelecionadaController : ControllerBase
    {
        private readonly IRespostaSelecionadaService _respostaSelecionadaService;

        public RespostaSelecionadaController(IRespostaSelecionadaService respostaSelecionadaService)
        {
            _respostaSelecionadaService = respostaSelecionadaService;
        }

        [HttpGet("/RespostaSelecionada")]
        public async Task<IActionResult> ObterRespostaSelecionadaPorIdAsync(int idRespostaSelecionada)
        {
            var result = await _respostaSelecionadaService.ObterRespostaSelecionadaPorIdAsync(idRespostaSelecionada);

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

        [HttpGet("/RespostasSelecionadas")]
        public async Task<IActionResult> ObterRespostasSelecionadasAsync([FromQuery] int pageNumber, int pageSize)
        {
            var result = await _respostaSelecionadaService.ObterRespostasSelecionadasAsync(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRespostaSelecionadaAsync(RespostaSelecionadaDto respostaSelecionadaDto)
        {
            var result = await _respostaSelecionadaService.AdicionarRespostaSelecionadaAsync(respostaSelecionadaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarRespostaSelecionadaAsync(int respostaSelecionadaId, RespostaSelecionadaDto respostaSelecionadaDto)
        {
            var result = await _respostaSelecionadaService.AtualizarRespostaSelecionadaAsync(respostaSelecionadaId, respostaSelecionadaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirRespostaSelecionadaAsync(int respostaSelecionadaId)
        {
            var result = await _respostaSelecionadaService.ExcluirRespostaSelecionadaAsync(respostaSelecionadaId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }

}
