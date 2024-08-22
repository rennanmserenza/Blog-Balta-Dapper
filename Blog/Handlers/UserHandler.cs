using Blog.Architecture.Handler;
using Blog.Models;
using Blog.Repositories;
using System.Data.SqlClient;

namespace Blog.Handlers
{
    public class UserHandler : BaseHandler<User>
    {
        #region CRUD User

        public List<User> ObterUsuariosEPerfis(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            return repository.ObterUsersWithRoles();
        }

        #endregion
    }
}
