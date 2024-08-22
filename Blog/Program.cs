using Blog.Architecture.Menu;
using Blog.Architecture.Repository;
using Blog.Models;
using System.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);

            while (true)
            {
                var opt = Menu.ChamaMenu();
                SelecionadorDeCrud(connection, opt);
            }
        }

        public static void SelecionadorDeCrud(SqlConnection connection, int option)
        {
            switch (option)
            {
                case 0: Environment.Exit(0); break; // Encerra o Programa
                case 1: Menu.ChamaMenuUsuario(connection); break;
                //case 2: CrudUsuario(2); break;
                //case 3: CrudUsuario(3); break;
                //case 4: CrudUsuario(4); break;
                //case 5: CrudUsuario(5); break;
                //case 6: CrudUsuario(6); break;
                default: Menu.MenuExceptionMessage(option); Menu.ChamaMenu(); break;
            }
        }

        #region CRUD Role

        public static void ReadRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Obter(1);

            Console.WriteLine(role.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.ObterTodos();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateRole(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            role.Id = (int)repository.Incluir(role);
            Console.WriteLine($"{role.Name} inserido no banco de dados.");
        }

        public static void UpdateRole(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            repository.Alterar(role);
            Console.WriteLine($"{role.Name} atualizado no banco de dados.");
        }

        public static void DeleteRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Obter(2);
            repository.Excluir(role);
            Console.WriteLine($"{role.Name} deletado do banco de dados.");
        }

        #endregion

        #region CRUD Tag

        public static void ReadTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var item = repository.Obter(1);
            Console.WriteLine(item.Name);
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.ObterTodos();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateTag(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            role.Id = (int)repository.Incluir(role);
            Console.WriteLine($"{role.Name} inserido no banco de dados.");
        }

        public static void UpdateTag(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            repository.Alterar(role);
            Console.WriteLine($"{role.Name} atualizado no banco de dados.");
        }

        public static void DeleteTag(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Obter(2);
            repository.Excluir(role);
            Console.WriteLine($"{role.Name} deletado do banco de dados.");
        }

        #endregion

        #region CRUD Category

        public static void ReadCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var item = repository.Obter(1);
            Console.WriteLine(item.Name);
        }

        public static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.ObterTodos();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        public static void CreateCategory(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            role.Id = (int)repository.Incluir(role);
            Console.WriteLine($"{role.Name} inserido no banco de dados.");
        }

        public static void UpdateCategory(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            repository.Alterar(role);
            Console.WriteLine($"{role.Name} atualizado no banco de dados.");
        }

        public static void DeleteCategory(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Obter(2);
            repository.Excluir(role);
            Console.WriteLine($"{role.Name} deletado do banco de dados.");
        }

        #endregion

        #region CRUD Post

        public static void ReadPost(SqlConnection connection)
        {
            var repository = new Repository<Post>(connection);
            var item = repository.Obter(1);
            Console.WriteLine(item.Title);
        }

        public static void ReadPosts(SqlConnection connection)
        {
            var repository = new Repository<Post>(connection);
            var items = repository.ObterTodos();

            foreach (var item in items)
                Console.WriteLine(item.Title);
        }

        public static void CreatePost(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            role.Id = (int)repository.Incluir(role);
            Console.WriteLine($"{role.Name} inserido no banco de dados.");
        }

        public static void UpdatePost(SqlConnection connection)
        {
            var role = new Role
            {
                Id = 2,
                Name = "Mariana Guntzel Serenza",
                Slug = "mariana-guntzel"
            };

            var repository = new Repository<Role>(connection);
            repository.Alterar(role);
            Console.WriteLine($"{role.Name} atualizado no banco de dados.");
        }

        public static void DeletePost(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Obter(2);
            repository.Excluir(role);
            Console.WriteLine($"{role.Name} deletado do banco de dados.");
        }

        #endregion
    }
}