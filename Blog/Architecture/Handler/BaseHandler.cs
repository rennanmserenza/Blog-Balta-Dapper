using Blog.Architecture.Model;
using Blog.Architecture.Repository;
using System.Data.SqlClient;

namespace Blog.Architecture.Handler
{
    public class BaseHandler<T> where T : BaseForm
    {
        #region CRUD User

        public T Obter(SqlConnection connection, int id)
        {
            var repository = new Repository<T>(connection);
            return repository.Obter(id);
        }

        public IEnumerable<T> ObterTodos(SqlConnection connection)
        {
            var repository = new Repository<T>(connection);
            return repository.ObterTodos();
        }

        public bool Incluir(SqlConnection connection, T model)
        {
            if (model is null) return false;

            var repository = new Repository<T>(connection);
            model.Id = repository.Incluir(model);

            return model.Id != 0;
        }

        public bool Alterar(SqlConnection connection, T model)
        {
            var repository = new Repository<T>(connection);
            return repository.Alterar(model);
        }

        public bool Excluir(SqlConnection connection, int id)
        {
            var repository = new Repository<T>(connection);
            return repository.Excluir(id);
        }

        public bool Excluir(SqlConnection connection, T model)
        {
            var repository = new Repository<T>(connection);
            return repository.Excluir(model);
        }

        #endregion
    }
}
