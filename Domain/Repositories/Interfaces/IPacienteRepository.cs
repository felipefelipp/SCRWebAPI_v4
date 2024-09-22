using Domain.AggregatesModel.Cliente;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> AdicionarPaciente(Paciente paciente);
        Task<Paciente> ObterPaciente(int? id = null,
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
                                     string? profissao = null);
        Task<List<Paciente>> ObterPacientes(Parameters parameters);
        Task<bool> AtualizarPaciente(Paciente paciente);
    }
}
