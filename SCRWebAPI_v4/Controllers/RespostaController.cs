using Microsoft.AspNetCore.Mvc;
using SCRWebAPI_v4.Domain.Dto;
using SCRWebAPI_v4.Domain.Services.Interfaces;

namespace SCRWebAPI_v4.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        private readonly IRespostaService _respostaService;
        public RespostaController(IRespostaService respostaService)
        {
            _respostaService = respostaService;
        }

        [HttpGet("/Resposta")]
        public async Task<IActionResult> ObterRespostaPorIdAsync(int idResposta)
        {
            var result = await _respostaService.ObterRespostaPorIdAsync(idResposta);

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

        [HttpGet("/Respostas")]
        public async Task<IActionResult> ObterRespostasAsync([FromQuery] int pageNumber, int pageSize)
        {
            var result = await _respostaService.ObterRespostasAsync(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarRespostaAsync(RespostaDto respostaDto)
        {
            var result = await _respostaService.AdicionarRespostaAsync(respostaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarRespostaAsync(int respostaId, RespostaDto respostaDto)
        {
            var result = await _respostaService.AtualizarRespostaAsync(respostaId, respostaDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirRespostaAsync(int respostaId)
        {
            var result = await _respostaService.ExcluirRespostaAsync(respostaId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
