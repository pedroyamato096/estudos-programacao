namespace ControleEstoqueCompleto.Util
{
    public static class Entrada
    {
        public static int LerOpcao(int minimo, int maximo)
        {
            while (true)
            {
                try
                {
                    Console.Write("Escolha uma opção: ");
                    int opcao = int.Parse(Console.ReadLine()!);

                    if (opcao >= minimo && opcao <= maximo)
                        return opcao;

                    Console.WriteLine("Erro: opção inválida.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: digite apenas números.");
                }
            }
        }

        public static string LerNomeProduto()
        {
            while (true)
            {
                Console.Write("Nome do produto: ");
                string nome = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(nome) && nome.Any(char.IsLetter))
                    return nome.Trim();

                Console.WriteLine("Erro: digite um nome de produto válido.");
            }
        }

        public static int LerInteiro(string mensagem, int valorMinimo = 0)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensagem);
                    int valor = int.Parse(Console.ReadLine()!);

                    if (valor >= valorMinimo)
                        return valor;

                    Console.WriteLine($"Erro: o valor deve ser maior ou igual a {valorMinimo}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: digite apenas números inteiros.");
                }
            }
        }

        public static decimal LerDecimal(string mensagem)
        {
            while (true)
            {
                try
                {
                    Console.Write(mensagem);
                    decimal valor = decimal.Parse(Console.ReadLine()!);

                    if (valor >= 0)
                        return valor;

                    Console.WriteLine("Erro: o valor não pode ser negativo.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: digite um valor válido.");
                }
            }
        }
    }
}
