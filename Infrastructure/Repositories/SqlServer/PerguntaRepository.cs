using Dapper;
using Domain.AggregatesModel.Classificacao;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Infrastructure.Scripts;
using System.Data;

namespace SCRWebAPI_v4.Infrastructure.Repositories.SqlServer
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly ILogger<PerguntaRepository> _logger;
        private readonly DapperContext _context;
        public PerguntaRepository(DapperContext context, ILogger<PerguntaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Pergunta> AdicionarPerguntaAsync(Pergunta pergunta)
        {
            try
            {
                var query = PerguntaScript.AdicionarPergunta;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("DescricaoPergunta", pergunta.DescricaoPergunta, DbType.String);
                parameters.Add("CategoriaPerguntaId", pergunta.CategoriaPerguntaId, DbType.Int32);
                parameters.Add("InseridoEm", DateTime.Now, DbType.DateTime);
                parameters.Add("InseridoPor", 1, DbType.Int32);
                parameters.Add("ModificadoEm", DateTime.Now, DbType.DateTime);
                parameters.Add("ModificadoPor", 1, DbType.Int32);

                var perguntaId = await connection.ExecuteScalarAsync<int>(query, parameters);

                return await ObterPerguntaPorIdAsync(perguntaId);
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao obter perguntas", ex);
            }
        }

        public async Task<bool> AtualizarPerguntaAsync(Pergunta pergunta)
        {
            try
            {
                var parameters = new DynamicParameters();
                var updateFields = new List<string>();
                var conditionFields = new List<string>();

                if (!string.IsNullOrEmpty(pergunta.DescricaoPergunta))
                {
                    updateFields.Add(" DescricaoPergunta = @DescricaoPergunta");
                    parameters.Add("DescricaoPergunta", pergunta.DescricaoPergunta, DbType.String);
                }

                if (pergunta.CategoriaPerguntaId.HasValue)
                {
                    updateFields.Add(" CategoriaPerguntaId = @CategoriaPerguntaId");
                    parameters.Add("CategoriaPerguntaId", pergunta.CategoriaPerguntaId, DbType.Int32);
                }

                if (pergunta.PerguntaId > 0)
                {
                    conditionFields.Add(" AND PerguntaId = @PerguntaId");
                    parameters.Add("PerguntaId", pergunta.PerguntaId, DbType.Int32);
                }

                var query = $@"
                    UPDATE Pergunta
                    SET {string.Join(", ", updateFields)}
                    WHERE 1=1
                    {string.Join(" AND ", conditionFields)}";

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
                throw new Exception("Erro ao atualizar pergunta", ex);
            }
        }

        public async Task<Pergunta> ObterPerguntaPorIdAsync(int id)
        {
            try
            {
                var query = PerguntaScript.ObterPergunta;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("PerguntaId", id, DbType.Int32);

                var result = await connection.QueryAsync<Pergunta>(query, parameters);

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
                throw new Exception("Erro ao obter perguntas", ex);
            }
        }

        public async Task<List<Pergunta>> ObterPerguntasAsync(Parameters parameters)
        {
            try
            {
                var query = PerguntaScript.ObterPerguntas;
                using var connection = _context.CreateConnection();
                
                var result = await connection.QueryAsync<Pergunta>(query, parameters);

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
                throw new Exception("Erro ao obter perguntas", ex);
            }
        }

        public async Task<bool> ExcluirPerguntaAsync(int perguntaId)
        {
            try
            {
                var query = PerguntaScript.ExcluirPergunta;
                
                var parameters = new DynamicParameters();
                parameters.Add("PerguntaId", perguntaId, DbType.Int32);

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
                throw new Exception("Erro ao atualizar pergunta", ex);
            }
        }
    }
}
