using Dapper;
using Domain.AggregatesModel.Classificacao;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Infrastructure.Scripts;
using System.Data;
using System.Text;

namespace SCRWebAPI_v4.Infrastructure.Repositories.SqlServer
{
    public class RespostaSelecionadaRepository : IRespostaSelecionadaRepository
    {
        private readonly ILogger<RespostaSelecionadaRepository> _logger;
        private readonly DapperContext _context;

        public RespostaSelecionadaRepository(DapperContext context, ILogger<RespostaSelecionadaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RespostaSelecionada> AdicionarRespostaSelecionadaAsync(RespostaSelecionada respostaSelecionada)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("PerguntaId", respostaSelecionada.PerguntaId, DbType.Int32);
                parameters.Add("RespostaId", respostaSelecionada.RespostaId, DbType.Int32);
                parameters.Add("ValorRespostaTexto", respostaSelecionada.ValorRespostaTexto, DbType.String);
                parameters.Add("ValorRespostaTextoArea", respostaSelecionada.ValorRespostaTextoArea, DbType.String);
                parameters.Add("ClassificacaoPacienteId", respostaSelecionada.ClassificacaoPacienteId, DbType.Int32);
                parameters.Add("RespostaDateTime", respostaSelecionada.RespostaDateTime, DbType.DateTime);
                parameters.Add("InseridoEm", DateTime.Now, DbType.DateTime);
                parameters.Add("InseridoPor", 1, DbType.Int32);
                parameters.Add("ModificadoEm", DateTime.Now, DbType.DateTime);
                parameters.Add("ModificadoPor", 1, DbType.Int32);

                var query = RespostaSelecionadaScript.AdicionarRespostaSelecionada;

                using var connection = _context.CreateConnection();
                var respostaSelecionadaId = await connection.ExecuteScalarAsync<int>(query, parameters);

                return await ObterRespostaSelecionadaPorIdAsync(respostaSelecionadaId);
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar resposta selecionada", ex);
            }
        }

        public async Task<RespostaSelecionada> ObterRespostaSelecionadaPorIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID inválido", nameof(id));
            }

            try
            {
                var query = RespostaSelecionadaScript.ObterRespostaSelecionada;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("RespostaSelecionadaId", id, DbType.Int32);

                var result = await connection.QueryAsync<RespostaSelecionada>(query, parameters);

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
                throw new Exception("Erro ao obter resposta selecionada", ex);
            }
        }

        public async Task<List<RespostaSelecionada>> ObterRespostasSelecionadasAsync(Parameters parameters)
        {
            try
            {
                var query = RespostaSelecionadaScript.ObterRespostasSelecionadas;
                using var connection = _context.CreateConnection();

                var result = await connection.QueryAsync<RespostaSelecionada>(query.ToString(), new { Offset = parameters.OffSet, PageSize = parameters.PageSize });

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
                throw new Exception("Erro ao obter respostas selecionadas", ex);
            }
        }

        public async Task<bool> AtualizarRespostaSelecionadaAsync(RespostaSelecionada respostaSelecionada)
        {
            try
            {
                var parameters = new DynamicParameters();
                var updateFields = new List<string>();

                parameters.Add("RespostaSelecionadaId", respostaSelecionada.RespostaSelecionadaId, DbType.Int32);

                if (respostaSelecionada.PerguntaId > 0)
                {
                    updateFields.Add("PerguntaId = @PerguntaId");
                    parameters.Add("PerguntaId", respostaSelecionada.PerguntaId, DbType.Int32);
                }

                if (respostaSelecionada.RespostaId > 0)
                {
                    updateFields.Add("RespostaId = @RespostaId");
                    parameters.Add("RespostaId", respostaSelecionada.RespostaId, DbType.Int32);
                }

                if (!string.IsNullOrEmpty(respostaSelecionada.ValorRespostaTexto))
                {
                    updateFields.Add("ValorRespostaTexto = @ValorRespostaTexto");
                    parameters.Add("ValorRespostaTexto", respostaSelecionada.ValorRespostaTexto, DbType.String);
                }

                if (!string.IsNullOrEmpty(respostaSelecionada.ValorRespostaTextoArea))
                {
                    updateFields.Add("ValorRespostaTextoArea = @ValorRespostaTextoArea");
                    parameters.Add("ValorRespostaTextoArea", respostaSelecionada.ValorRespostaTextoArea, DbType.String);
                }

                if (respostaSelecionada.ClassificacaoPacienteId > 0)
                {
                    updateFields.Add("ClassificacaoPacienteId = @ClassificacaoPacienteId");
                    parameters.Add("ClassificacaoPacienteId", respostaSelecionada.ClassificacaoPacienteId, DbType.Int32);
                }

                if (respostaSelecionada.RespostaDateTime.HasValue)
                {
                    updateFields.Add("RespostaDateTime = @RespostaDateTime");
                    parameters.Add("RespostaDateTime", respostaSelecionada.RespostaDateTime, DbType.DateTime);
                }

                var query = new StringBuilder();
                query.AppendLine("UPDATE RespostaSelecionada SET");
                query.AppendLine(string.Join(", ", updateFields));
                query.AppendLine("WHERE RespostaSelecionadaId = @RespostaSelecionadaId");

                using var connection = _context.CreateConnection();
                var rowsAffected = await connection.ExecuteAsync(query.ToString(), parameters);

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
                throw new Exception("Erro ao atualizar resposta selecionada", ex);
            }
        }

        public async Task<bool> ExcluirRespostaSelecionadaAsync(int respostaselecionadaId)
        {
            if (respostaselecionadaId <= 0)
            {
                throw new ArgumentException("ID de resposta selecionada inválido", nameof(respostaselecionadaId));
            }

            try
            {
                var query = RespostaSelecionadaScript.ExcluirRespostaSelecionada;

                var parameters = new DynamicParameters();
                parameters.Add("RespostaSelecionadaId", respostaselecionadaId, DbType.Int32);

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
                throw new Exception("Erro ao excluir resposta selecionada", ex);
            }
        }
    }
}
