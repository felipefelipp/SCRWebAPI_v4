using Dapper;
using Infrastructure.Context;
using Infrastructure.Repositories.Interfaces;
using System.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories.SqlServer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DapperContext _context;

        public Repository(DapperContext context)
        {
            _context = context;
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            var query = $"SELECT * FROM {typeof(T).Name} WHERE {predicate}";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(query);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = $"SELECT * FROM {typeof(T).Name}";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<T>(query);
        }

        public async Task<T> Create(T entity)
        {
            var query = $"INSERT INTO {typeof(T).Name} VALUES (@Entity)";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Entity = entity });
            return entity;
        }

        public async Task Update(T entity)
        {
            var query = $"UPDATE {typeof(T).Name} SET @Entity WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Entity = entity, ((dynamic)entity).Id });
        }

        public async Task Delete(int id)
        {
            var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
