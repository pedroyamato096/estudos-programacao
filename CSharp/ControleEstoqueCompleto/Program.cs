using ControleEstoqueCompleto.Models;
using ControleEstoqueCompleto.Util;

List<Produto> produtos = ArquivoEstoque.CarregarProdutos();
int opcao = 0;

while (opcao != 4)
{
    ExibirMenu();
    opcao = Entrada.LerOpcao(1, 4);

    switch (opcao)
    {
        case 1:
            CadastrarProduto(produtos);
            break;

        case 2:
            ListarProdutos(produtos);
            break;

        case 3:
            RegistrarVenda(produtos);
            break;

        case 4:
            Console.WriteLine("Fim do programa.");
            break;
    }
}

static void ExibirMenu()
{
    Console.WriteLine("\n===== CONTROLE DE ESTOQUE =====");
    Console.WriteLine("[1] Cadastrar produto");
    Console.WriteLine("[2] Listar produtos");
    Console.WriteLine("[3] Registrar venda");
    Console.WriteLine("[4] Sair");
}

static void CadastrarProduto(List<Produto> produtos)
{
    Console.WriteLine("\n--- Cadastro de Produto ---");

    string nome = Entrada.LerNomeProduto();
    int quantidade = Entrada.LerInteiro("Quantidade em estoque: ");
    decimal preco = Entrada.LerDecimal("Preço unitário: R$ ");
    int estoqueMinimo = Entrada.LerInteiro("Estoque mínimo: ");

    int estoqueMaximo;
    do
    {
        estoqueMaximo = Entrada.LerInteiro("Estoque máximo: ");

        if (estoqueMaximo < estoqueMinimo)
            Console.WriteLine("Erro: o estoque máximo deve ser maior ou igual ao estoque mínimo.");

    } while (estoqueMaximo < estoqueMinimo);

    try
    {
        Produto produto = new Produto(nome, quantidade, preco, estoqueMinimo, estoqueMaximo);
        produtos.Add(produto);
        ArquivoEstoque.SalvarProdutos(produtos);

        Console.WriteLine("Produto cadastrado com sucesso!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Erro: " + ex.Message);
    }
}

static void ListarProdutos(List<Produto> produtos)
{
    Console.WriteLine("\n--- Produtos Cadastrados ---");

    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    for (int i = 0; i < produtos.Count; i++)
    {
        Console.WriteLine($"\nProduto {i + 1}");
        produtos[i].Exibir();
    }
}

static void RegistrarVenda(List<Produto> produtos)
{
    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    Console.WriteLine("\n--- Registrar Venda ---");

    for (int i = 0; i < produtos.Count; i++)
        Console.WriteLine($"[{i + 1}] {produtos[i].Nome} - Estoque: {produtos[i].QuantidadeEmEstoque}");

    int produtoEscolhido = Entrada.LerOpcao(1, produtos.Count) - 1;
    int quantidadeVendida = Entrada.LerInteiro("Quantidade vendida: ", 1);

    Produto produto = produtos[produtoEscolhido];

    if (!produto.RegistrarVenda(quantidadeVendida))
    {
        Console.WriteLine("Erro: quantidade solicitada maior que o estoque disponível.");
        return;
    }

    ArquivoEstoque.SalvarProdutos(produtos);

    Console.WriteLine("Venda registrada com sucesso!");
    Console.WriteLine($"Estoque atual: {produto.QuantidadeEmEstoque}");
    Console.WriteLine(produto.VerificarSituacaoEstoque());
}
