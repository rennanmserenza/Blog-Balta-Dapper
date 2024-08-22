namespace Blog.Extensions
{
    public static class StringExtensions
    {
        public static string lerNumero()
        {
            ConsoleKeyInfo cki;
            string entrada = "";

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Backspace)
                    {
                        if (entrada.Length == 0) continue;
                        entrada = "";
                        Console.Write("\b \b"); //Remove o último caractere digitado
                    }
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        if (!string.IsNullOrEmpty(entrada))
                            break;
                    }
                    if ((ConsoleKey.D0 <= cki.Key) && (cki.Key <= ConsoleKey.D9) ||
                        (ConsoleKey.NumPad0 <= cki.Key) && (cki.Key <= ConsoleKey.NumPad9))
                    {
                        if (string.IsNullOrEmpty(entrada))
                        {
                            entrada += cki.KeyChar;
                            Console.Write(cki.KeyChar);
                        }
                    }

                }
            }

            return entrada;
        }

        public static string lerNumeros()
        {
            ConsoleKeyInfo cki;
            string entrada = "";

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Backspace)
                    {
                        if (entrada.Length == 0) continue;
                        entrada = entrada.Remove(entrada.Length - 1);
                        Console.Write("\b \b"); //Remove o último caractere digitado
                    }
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        if (!string.IsNullOrEmpty(entrada))
                            break;
                    }
                    if ((ConsoleKey.D0 <= cki.Key) && (cki.Key <= ConsoleKey.D9) ||
                        (ConsoleKey.NumPad0 <= cki.Key) && (cki.Key <= ConsoleKey.NumPad9))
                    {
                        entrada += cki.KeyChar;
                        Console.Write(cki.KeyChar);
                    }

                }
            }

            return entrada;
        }
    }
}
