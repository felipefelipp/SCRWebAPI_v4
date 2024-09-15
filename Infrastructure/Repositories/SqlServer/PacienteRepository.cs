using AutoMapper;
using Dapper;
using Domain.AggregatesModel.Cliente;
using Infrastructure.Context;
using Infrastructure.Models.Cliente;
using Infrastructure.Repositories.Interfaces;
using Infrastructure.Scripts;

namespace Infrastructure.Repositories.SqlServer
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        private readonly IMapper _mapper;
        public PacienteRepository(DapperContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public async Task<Paciente> ObterPacientePorId(int id)
        {
            var query = PacienteScripts.ObterPacientePorId;

            var parameters = new DynamicParameters();
            parameters.Add("@idPaciente", id);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryAsync<PacienteModel>(query, parameters);
            return _mapper.Map<Paciente>(result.FirstOrDefault());
        }

    }
}
