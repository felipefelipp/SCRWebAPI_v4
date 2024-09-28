using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerguntaController : ControllerBase
    {
        private readonly IPerguntaService _perguntaService;
        public PerguntaController(IPerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }


        [HttpGet("/Pergunta")]
        public async Task<IActionResult> ObterPerguntaPorIdAsync(int idPergunta)
        {
            var result = await _perguntaService.ObterPerguntaPorIdAsync(idPergunta);

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

        [HttpGet("/Perguntas")]
        public async Task<IActionResult> ObterPerguntasAsync([FromQuery] int pageNumber, int pageSize)
        {
            var result = await _perguntaService.ObterPerguntasAsync(pageNumber, pageSize);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AdicionarPerguntaAsync(PerguntaDto perguntaDto)
        {
            var result = await _perguntaService.AdicionarPerguntaAsync(perguntaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
            
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPerguntaAsync(int perguntaId, PerguntaDto perguntaDto)
        {
            var result = await _perguntaService.AtualizarPerguntaAsync(perguntaId, perguntaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirPerguntaAsync(int perguntaId)
        {
            var result = await _perguntaService.ExcluirPerguntaAsync(perguntaId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
