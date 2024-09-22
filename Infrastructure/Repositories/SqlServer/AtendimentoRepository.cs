using Dapper;
using Domain.AggregatesModel.Atendimento;
using Infrastructure.Context;
using Infrastructure.Repositories.SqlServer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Infrastructure.Scripts;
using System.Data;
using System.Text;

namespace SCRWebAPI_v4.Infrastructure.Repositories.SqlServer
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ILogger<PacienteRepository> _logger;
        private readonly DapperContext _context;
        public AtendimentoRepository(DapperContext context, ILogger<PacienteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<AtendimentoPaciente> AdicionarAtendimentoAsync(AtendimentoPaciente atendimentoPaciente)
        {
            try
            {
                var query = AtendimentoScript.AdicionarAtendimento;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("PacienteId", atendimentoPaciente.PacienteId, DbType.Int32);
                parameters.Add("SenhaClassificacao", atendimentoPaciente.SenhaClassificacao, DbType.String);
                parameters.Add("DataAtendimento", DateTime.Now, DbType.DateTime);
                parameters.Add("InseridoPor", 1, DbType.Int16);
                parameters.Add("InseridoEm", DateTime.Now, DbType.DateTime);

                var atendimentoPacienteId = await connection.ExecuteScalarAsync<int>(query, parameters);

                return await ObterAtendimentoPorIdAsync(atendimentoPacienteId);
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar paciente", ex);
            }

        }

        public async Task<bool> AtualizarIdPacienteAtendimentoAsync(int pacienteId, int atendimentoPacienteId)
        {
            try
            {
                var query = AtendimentoScript.AtualizarIdPacienteAtendimento;
                var parameters = new DynamicParameters();
                parameters.Add("PacienteId", pacienteId, DbType.Int32);
                parameters.Add("AtendimentoPacienteId", atendimentoPacienteId, DbType.Int32);

                using var connection = _context.CreateConnection();
                var rowsAffected = await connection.ExecuteAsync(query, parameters);

                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao atualizar paciente", ex);
            }
        }

        public async Task<AtendimentoPaciente> ObterAtendimentoPorIdAsync(int atendimentoPacienteId)
        {
            try
            {
                var query = AtendimentoScript.ObterAtendimentoPorId;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("AtendimentoPacienteId", atendimentoPacienteId, DbType.Int32);

                var result = await connection.QueryAsync<AtendimentoPaciente>(query.ToString(), parameters);

                return result.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar paciente", ex);
            }
        }

        public async Task<List<AtendimentoPaciente>> ObterAtendimentosPacienteAsync(int idPaciente)
        {
            try
            {
                var query = AtendimentoScript.ObterAtendimentosPorIdPaciente;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("PacenteId", idPaciente, DbType.Int32);

                var result = await connection.QueryAsync<AtendimentoPaciente>(query.ToString(), parameters);

                return result.ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar paciente", ex);
            }
        }

        public async Task<List<AtendimentoPaciente>> ObterAtendimentosAsync(Parameters parameters)
        {
            try
            {
                var query = new StringBuilder(AtendimentoScript.ObterAtendimentos);
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<AtendimentoPaciente>(query.ToString(), new { Offset = parameters.OffSet, PageSize = parameters.PageSize });
                return result.ToList();
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao obter pacientes", ex);
            }
        }
    }
}
