using Dapper;
using Domain.AggregatesModel.Classificacao;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using SCRWebAPI_v4.Domain.AggregatesModel.Pagination;
using SCRWebAPI_v4.Domain.Repositories.Interfaces;
using SCRWebAPI_v4.Infrastructure.Scripts;
using System.Data;

namespace SCRWebAPI_v4.Infrastructure.Repositories.SqlServer
{
    public class RespostaRepository : IRespostaRepository
    {
        private readonly ILogger<RespostaRepository> _logger;
        private readonly DapperContext _context;
        public RespostaRepository(DapperContext context, ILogger<RespostaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Resposta> AdicionarRespostaAsync(Resposta resposta)
        {
            try
            {
                var parameters = new DynamicParameters();
                var insertFields = new List<string>();
                var insertValues = new List<string>();

                if (!string.IsNullOrEmpty(resposta.RespostaTexto))
                {
                    insertFields.Add("RespostaTexto");
                    insertValues.Add("@RespostaTexto");
                    parameters.Add("RespostaTexto", resposta.RespostaTexto, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaTextoArea))
                {
                    insertFields.Add("RespostaTextoArea");
                    insertValues.Add("@RespostaTextoArea");
                    parameters.Add("RespostaTextoArea", resposta.RespostaTextoArea, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaCheckBox))
                {
                    insertFields.Add("RespostaCheckBox");
                    insertValues.Add("@RespostaCheckBox");
                    parameters.Add("RespostaCheckBox", resposta.RespostaCheckBox, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaComboBox))
                {
                    insertFields.Add("RespostaComboBox");
                    insertValues.Add("@RespostaComboBox");
                    parameters.Add("RespostaComboBox", resposta.RespostaComboBox, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaRadioButtom))
                {
                    insertFields.Add("RespostaRadioButtom");
                    insertValues.Add("@RespostaRadioButtom");
                    parameters.Add("RespostaRadioButtom", resposta.RespostaRadioButtom, DbType.String);
                }

                if (resposta.RespostaDateTime.HasValue)
                {
                    insertFields.Add("RespostaDateTime");
                    insertValues.Add("@RespostaDateTime");
                    parameters.Add("RespostaDateTime", resposta.RespostaDateTime, DbType.DateTime);
                }

                if (resposta.RespostaNumeric.HasValue)
                {
                    insertFields.Add("RespostaNumeric");
                    insertValues.Add("@RespostaNumeric");
                    parameters.Add("RespostaNumeric", resposta.RespostaNumeric, DbType.Int32);
                }

                if (resposta.PontuacaoResposta.HasValue)
                {
                    insertFields.Add("PontuacaoResposta");
                    insertValues.Add("@PontuacaoResposta");
                    parameters.Add("PontuacaoResposta", resposta.PontuacaoResposta, DbType.Int32);
                }

                if (resposta.IdPergunta.HasValue)
                {
                    insertFields.Add("IdPergunta");
                    insertValues.Add("@IdPergunta");
                    parameters.Add("IdPergunta", resposta.IdPergunta, DbType.Int32);
                }

                var query = $@"
                            INSERT INTO Resposta ({string.Join(", ", insertFields)})
                            OUTPUT INSERTED.RespostaId
                            VALUES ({string.Join(", ", insertValues)});
                            SELECT CAST(SCOPE_IDENTITY() as int)";

                using var connection = _context.CreateConnection();
                var respostaInseridaId = await connection.ExecuteScalarAsync<int>(query, parameters);

                return await ObterRespostaPorIdAsync(respostaInseridaId);
            }
            catch (SqlException ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao acessar o banco de dados", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Erro: {ex.Message}");
                throw new Exception("Erro ao adicionar resposta", ex);
            }
        }


        public async Task<bool> AtualizarRespostaAsync(Resposta resposta)
        {
            try
            {
                var parameters = new DynamicParameters();
                var updateFields = new List<string>();
                var conditionFields = new List<string>();

                if (!string.IsNullOrEmpty(resposta.RespostaTexto))
                {
                    updateFields.Add(" RespostaTexto = @RespostaTexto");
                    parameters.Add("RespostaTexto", resposta.RespostaTexto, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaTextoArea))
                {
                    updateFields.Add(" RespostaTextoArea = @RespostaTextoArea");
                    parameters.Add("RespostaTextoArea", resposta.RespostaTextoArea, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaCheckBox))
                {
                    updateFields.Add(" RespostaCheckBox = @RespostaCheckBox");
                    parameters.Add("RespostaCheckBox", resposta.RespostaCheckBox, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaComboBox))
                {
                    updateFields.Add(" RespostaComboBox = @RespostaComboBox");
                    parameters.Add("RespostaComboBox", resposta.RespostaComboBox, DbType.String);
                }

                if (!string.IsNullOrEmpty(resposta.RespostaRadioButtom))
                {
                    updateFields.Add(" RespostaRadioButtom = @RespostaRadioButtom");
                    parameters.Add("RespostaRadioButtom", resposta.RespostaRadioButtom, DbType.String);
                }

                if (resposta.RespostaDateTime.HasValue)
                {
                    updateFields.Add(" RespostaDateTime = @RespostaDateTime");
                    parameters.Add("RespostaDateTime", resposta.RespostaDateTime, DbType.DateTime);
                }

                if (resposta.RespostaNumeric.HasValue)
                {
                    updateFields.Add(" RespostaNumeric = @RespostaNumeric");
                    parameters.Add("RespostaNumeric", resposta.RespostaNumeric, DbType.Int32);
                }

                if (resposta.PontuacaoResposta.HasValue)
                {
                    updateFields.Add(" PontuacaoResposta = @PontuacaoResposta");
                    parameters.Add("PontuacaoResposta", resposta.PontuacaoResposta, DbType.Int32);
                }

                if (resposta.IdPergunta.HasValue)
                {
                    updateFields.Add(" IdPergunta = @IdPergunta");
                    parameters.Add("IdPergunta", resposta.IdPergunta, DbType.Int32);
                }

                if (resposta.RespostaId > 0)
                {
                    conditionFields.Add(" AND RespostaId = @RespostaId");
                    parameters.Add("RespostaId", resposta.RespostaId, DbType.Int32);
                }

                var query = $@"
                            UPDATE Resposta
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
                throw new Exception("Erro ao atualizar resposta", ex);
            }
        }

        public async Task<Resposta> ObterRespostaPorIdAsync(int id)
        {
            try
            {
                var query = RespostaScript.ObterResposta;
                using var connection = _context.CreateConnection();

                var parameters = new DynamicParameters();
                parameters.Add("RespostaId", id, DbType.Int32);

                var result = await connection.QueryAsync<Resposta>(query, parameters);

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
                throw new Exception("Erro ao obter resposta", ex);
            }
        }

        public async Task<List<Resposta>> ObterRespostasAsync(Parameters parameters)
        {
            try
            {
                var query = RespostaScript.ObterRespostas;
                using var connection = _context.CreateConnection();

                var result = await connection.QueryAsync<Resposta>(query, parameters);

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
                throw new Exception("Erro ao obter respostas", ex);
            }
        }
        public async Task<bool> ExcluirRespostaAsync(int respostaId)
        {
            try
            {
                var query = RespostaScript.ExcluirResposta;

                var parameters = new DynamicParameters();
                parameters.Add("RespostaId", respostaId, DbType.Int32);

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
                throw new Exception("Erro ao excluir resposta", ex);
            }
        }
    }
}
