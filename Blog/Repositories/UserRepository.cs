using Blog.Architecture.Repository;
using Blog.Models;
using Dapper;
using System.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository(SqlConnection connection) : Repository<User>(connection)
    {
        public List<User> ObterUsersWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] on [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr is null)
                    {
                        usr = user;
                        if (role is not null) usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else                    
                        usr.Roles.Add(role);                    

                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}
