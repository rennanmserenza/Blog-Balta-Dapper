using Blog.Extensions;
using System.Data.SqlClient;

namespace Blog.Architecture.Menu
{
    public static class Menu
    {
        public static int OpcaoSelecionada()
        {
            Console.Write("Opção selecionada: ");
            return int.Parse(StringExtensions.lerNumero());
        }

        public static int SelecioneValor()
        {
            Console.Write("Qual id deseja selecionar? ");
            return int.Parse(StringExtensions.lerNumeros());
        }

        public static void MenuExceptionMessage(int option)
        {
            Console.WriteLine($"\nA opção selecionada {option} não é válida. Selecione Novamente.");
            Thread.Sleep(2000);
        }

        public static void Rodape()
        {
            Console.WriteLine($"\n------------------------------------------------------------------------");

            Thread.Sleep(2000);
            Console.WriteLine("\n\nPressione Enter para prosseguir...");
            Console.ReadKey();
        }

        #region Menu Inicial

        public static int ChamaMenu()
        {
            Cabecalho();
            OpcoesCRUD();

            return OpcaoSelecionada();
        }

        private static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine($"\n------------------------------------------------------------------------");
            Console.WriteLine($"CRUD BLOG COM DAPPER");
        }

        private static void OpcoesCRUD()
        {
            Console.WriteLine($"\nQual opção deseja acessar?");
            Console.WriteLine($"1) CRUD Usuário");
            Console.WriteLine($"2) CRUD Perfil");
            Console.WriteLine($"3) CRUD Categoria");
            Console.WriteLine($"4) CRUD Tag");
            Console.WriteLine($"5) CRUD Tag");
            Console.WriteLine($"6) CRUD Post");
            Console.WriteLine($"\n0) Encerrar Programa");
            Console.WriteLine($"\n------------------------------------------------------------------------");
        }

        #endregion

        #region Menu CRUD

        public static void CabecalhoCRUD(string nomeCrud)
        {
            Console.Clear();
            Console.WriteLine($"\n------------------------------------------------------------------------");
            Console.WriteLine($"CRUD {nomeCrud}");
        }

        public static void ChamaMenuUsuario(SqlConnection connection)
        {
            var opt = 0;

            do
            {
                CabecalhoCRUD("USUÁRIO");
                UserMenu.OpcoesUsuario();

                opt = OpcaoSelecionada();
                if (opt != 0) UserMenu.SelecionadorCrudUsuario(connection, opt);
            } while (opt != 0);
        }

        #endregion
    }
}
