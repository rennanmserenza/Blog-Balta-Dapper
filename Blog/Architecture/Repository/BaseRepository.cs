using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Blog.Architecture.Repository
{
    // DAPPER NÃO POSSUI SAVE PARA EXECUTAR TRANSAÇÕES SE NÃO FOR UM TRANSACTION.
    // NÃO NECESSITA CRIAÇÃO DE UM MÉTODO SALVAR OU SALVARASYNC.

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SqlConnection _connection;

        public BaseRepository(SqlConnection connection) => _connection = connection;

        public T Obter(int id) => _connection.Get<T>(id);
        public IEnumerable<T> ObterTodos() => _connection.GetAll<T>();

        public long Incluir(T entity) => _connection.Insert(entity);
        public bool Alterar(T entity) => _connection.Update(entity);
        public bool Excluir(T entity) => _connection.Delete(entity);

        public async Task<long> IncluirAsync(T entity) => await _connection.InsertAsync(entity);
        public async Task AlterarAsync(T entity) => await _connection.UpdateAsync(entity);
        public async Task ExcluirAsync(T entity) => await _connection.DeleteAsync(entity);

        // Explorar demais métodos de connection.
    }
}
