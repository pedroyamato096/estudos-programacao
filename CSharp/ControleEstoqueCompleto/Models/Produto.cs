namespace ControleEstoqueCompleto.Models
{
    public class Produto
    {
        public string Nome { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int EstoqueMinimo { get; private set; }
        public int EstoqueMaximo { get; private set; }

        public Produto(string nome, int quantidadeEmEstoque, decimal precoUnitario,
            int estoqueMinimo, int estoqueMaximo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode estar vazio.");

            if (quantidadeEmEstoque < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            if (precoUnitario < 0)
                throw new ArgumentException("O preço unitário não pode ser negativo.");

            if (estoqueMinimo < 0)
                throw new ArgumentException("O estoque mínimo não pode ser negativo.");

            if (estoqueMaximo < estoqueMinimo)
                throw new ArgumentException("O estoque máximo deve ser maior ou igual ao estoque mínimo.");

            Nome = nome;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            PrecoUnitario = precoUnitario;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
        }

        public bool RegistrarVenda(int quantidade)
        {
            if (quantidade <= 0)
                return false;

            if (quantidade > QuantidadeEmEstoque)
                return false;

            QuantidadeEmEstoque -= quantidade;
            return true;
        }

        public string VerificarSituacaoEstoque()
        {
            if (QuantidadeEmEstoque < EstoqueMinimo)
                return "Estoque crítico - realizar reposição.";

            if (QuantidadeEmEstoque > EstoqueMaximo)
                return "Estoque acima do máximo - evitar novas compras.";

            return "Estoque adequado.";
        }

        public void Exibir()
        {
            Console.WriteLine($"Produto: {Nome}");
            Console.WriteLine($"Quantidade: {QuantidadeEmEstoque}");
            Console.WriteLine($"Preço unitário: R$ {PrecoUnitario:F2}");
            Console.WriteLine($"Estoque mínimo: {EstoqueMinimo}");
            Console.WriteLine($"Estoque máximo: {EstoqueMaximo}");
            Console.WriteLine($"Situação: {VerificarSituacaoEstoque()}");
        }
    }
}
