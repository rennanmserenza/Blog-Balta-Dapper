using Blog.Handlers;
using Blog.Models;
using System.Data.SqlClient;

namespace Blog.Architecture.Menu
{
    public static class UserMenu
    {
        #region Menu Usuário

        public static void OpcoesUsuario()
        {
            Console.WriteLine($"\nQual opção deseja acessar?");
            Console.WriteLine($"1) Obter usuário");
            Console.WriteLine($"2) Obter todos usuários");
            Console.WriteLine($"3) Obter usuários com perfis");
            Console.WriteLine($"4) Criar usuário");
            Console.WriteLine($"5) Editar usuário");
            Console.WriteLine($"6) Excluir usuário");
            Console.WriteLine($"\n0) Voltar");
            Console.WriteLine($"\n------------------------------------------------------------------------");
        }

        public static void SelecionadorCrudUsuario(SqlConnection connection, int option)
        {
            switch (option)
            {
                case 1: ListarUsuario(connection); break;
                case 2: ListarUsuarios(connection); break;
                case 3: ListarUsuariosEPerfis(connection); break;
                case 4: CriarUsuario(connection); break;
                case 5: EditarUsuario(connection); break;
                case 6: ExcluirUsuario(connection); break;
                default: Menu.MenuExceptionMessage(option); break;
            }
        }

        #region Obter

        private static void ListarUsuario(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nBusca de usuários selecionada.");
            var id = Menu.SelecioneValor();
            Console.WriteLine($"\n------------------------------------------------------------------------");

            var handler = new UserHandler();
            var user = handler.Obter(connection, id);

            if (user != null)
            {
                Console.WriteLine("\nBusca de usuários retornou o usuário selecionado.");
                Console.WriteLine($"Nome: {user.Name}, Email: {user.Email}, Bio: {user.Bio}");
            }
            else
                Console.WriteLine("\nBusca de usuários não encontrou o usuário selecionado.");

            Menu.Rodape();
        }

        private static void ListarUsuarios(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nBusca de todos usuários selecionada.");
            Console.WriteLine($"\n------------------------------------------------------------------------");

            var handler = new UserHandler();
            var users = handler.ObterTodos(connection);

            if (users.Any())
            {
                Console.WriteLine($"\nBusca de usuários retornou {users.Count()} usuários .");
                foreach (var user in users)
                    Console.WriteLine($"Nome: {user.Name}, Email: {user.Email}, Bio: {user.Bio}");
            }
            else
                Console.WriteLine("\nBusca de usuários não encontrou nenhum usuário.");

            Menu.Rodape();
        }

        private static void ListarUsuariosEPerfis(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nBusca de todos usuários e seus perfis selecionada.");
            Console.WriteLine($"\n------------------------------------------------------------------------");

            var handler = new UserHandler();
            var users = handler.ObterUsuariosEPerfis(connection);

            if (users.Any())
            {
                Console.WriteLine($"\nBusca de usuários retornou {users.Count()} usuários .");

                foreach (var user in users)
                {
                    Console.WriteLine($"Nome: {user.Name}");
                    foreach (var role in user.Roles)
                        Console.WriteLine($"\t - {role.Name}");
                }
            }
            else
                Console.WriteLine("\nBusca de usuários não encontrou nenhum usuário.");

            Menu.Rodape();
        }

        #endregion

        private static void CriarUsuario(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nInserção de usuários selecionada.");
            Console.WriteLine($"\n------------------------------------------------------------------------");

            var user = new User();

            Console.Write("\nNome: ");
            user.Name = Console.ReadLine() ?? string.Empty;
            Console.Write("Email: ");
            user.Email = Console.ReadLine() ?? string.Empty;
            Console.Write("Bio: ");
            user.Bio = Console.ReadLine() ?? string.Empty;
            Console.Write("Imagem: ");
            user.Image = Console.ReadLine() ?? string.Empty;
            Console.Write("Slug: ");
            user.Slug = Console.ReadLine() ?? string.Empty;
            Console.Write("Senha: ");
            user.PasswordHash = Console.ReadLine() ?? string.Empty;

            var handler = new UserHandler();
            var success = handler.Incluir(connection, user);

            if (success)
                Console.WriteLine("\nA inclusão de usuário retornou com sucesso.");
            else
                Console.WriteLine("\nA inclusão de usuário não foi executada com êxito.");

            Menu.Rodape();
        }

        private static void EditarUsuario(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nEdição de usuários selecionada.");
            Console.WriteLine($"\n------------------------------------------------------------------------");

            var handler = new UserHandler();
            int id = Menu.SelecioneValor();
            var user = handler.Obter(connection, id);

            if (user is not null)
            {
                Console.Write("\nBio: ");
                var bio = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(bio))
                    user.Bio = bio;

                Console.Write("Imagem: ");
                var img = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(img))
                    user.Image = img;

                Console.Write("Slug: ");
                var slug = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrEmpty(slug))
                    user.Slug = slug;

                var success = handler.Alterar(connection, user);

                if (success)
                    Console.WriteLine("\nA alteração de usuário retornou com sucesso.");
                else
                    Console.WriteLine("\nA alteração de usuário não foi executada com êxito.");
            }
            else
                Console.WriteLine("\nBusca de usuários não encontrou nenhum usuário.");

            Menu.Rodape();
        }

        private static void ExcluirUsuario(SqlConnection connection)
        {
            Menu.CabecalhoCRUD("USUÁRIO");
            Console.WriteLine("\n\nExclusão de usuários selecionada.");
            Console.WriteLine($"\n------------------------------------------------------------------------\n");

            var handler = new UserHandler();

            int id = Menu.SelecioneValor();
            var user = handler.Obter(connection, id);

            if (user is not null)
            {
                Console.WriteLine("\n\nUsuário retornado:");
                Console.WriteLine($"Nome: {user.Name}, Email: {user.Email}, Bio: {user.Bio}");

                Console.WriteLine("\nContinuar com a exclusão? ");
                var opt = Console.ReadLine();

                if (!string.IsNullOrEmpty(opt) && opt.ToLower() == "sim")
                {
                    var success = handler.Excluir(connection, user);

                    if (success)
                        Console.WriteLine("\nA exclusão de usuário retornou com sucesso.");
                    else
                        Console.WriteLine("\nA exclusão de usuário não foi executada com êxito.");
                }
            }
            else
                Console.WriteLine("\nBusca de usuários não encontrou nenhum usuário.");

            Menu.Rodape();
        }

        #endregion
    }
}
