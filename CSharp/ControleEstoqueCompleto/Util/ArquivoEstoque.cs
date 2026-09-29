using ControleEstoqueCompleto.Models;

namespace ControleEstoqueCompleto.Util
{
    public static class ArquivoEstoque
    {
        private static readonly string CaminhoArquivo = Path.Combine("Dados", "estoque.txt");

        public static void SalvarProdutos(List<Produto> produtos)
        {
            try
            {
                Directory.CreateDirectory("Dados");

                using StreamWriter arquivo = new StreamWriter(CaminhoArquivo, false);

                foreach (Produto produto in produtos)
                {
                    arquivo.WriteLine(
                        $"{produto.Nome};{produto.QuantidadeEmEstoque};{produto.PrecoUnitario};" +
                        $"{produto.EstoqueMinimo};{produto.EstoqueMaximo}"
                    );
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ao salvar o arquivo: " + ex.Message);
            }
        }

        public static List<Produto> CarregarProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            if (!File.Exists(CaminhoArquivo))
                return produtos;

            try
            {
                using StreamReader leitor = new StreamReader(CaminhoArquivo);
                string? linha;

                while ((linha = leitor.ReadLine()) != null)
                {
                    try
                    {
                        string[] dados = linha.Split(';');

                        if (dados.Length != 5)
                            throw new FormatException("Linha com quantidade incorreta de campos.");

                        string nome = dados[0];
                        int quantidade = int.Parse(dados[1]);
                        decimal preco = decimal.Parse(dados[2]);
                        int estoqueMinimo = int.Parse(dados[3]);
                        int estoqueMaximo = int.Parse(dados[4]);

                        produtos.Add(new Produto(nome, quantidade, preco, estoqueMinimo, estoqueMaximo));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Aviso: linha inválida ignorada: {linha}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Aviso: produto inválido ignorado: {ex.Message}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            }

            return produtos;
        }
    }
}
