using Domain.AggregatesModel.Atendimento;
using SCRWebAPI_v4.Domain.Dto;

namespace SCRWebAPI_v4.Domain.Services.Interfaces
{
    public interface IAtendimentoService
    {
        Task<ServiceResponse<AtendimentoPaciente>> AdicionarAtendimentoAsync(AtendimentoDto atendimentoDto);
        Task<ServiceResponse<AtendimentoPaciente>> AtualizarIdPacienteAtendimentoAsync(int atendimentoPacienteId, int pacienteId);
        Task<ServiceResponse<AtendimentoPaciente>> ObterAtendimentoPorIdAsync(int atendimentoPacienteId);
        Task<ServiceResponse<List<AtendimentoPaciente>>> ObterAtendimentosPacienteAsync(int atendimentoPacienteId);
        Task<ServiceResponse<List<AtendimentoPaciente>>> ObterAtendimentosAsync(int pageNumber, int pageSize);
    }
}
