using Domain.AggregatesModel.Cliente;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        Task<Paciente> ObterPacientePorId(int id);
        Task<Paciente> AdicionarPaciente(Paciente paciente);
    }
}
