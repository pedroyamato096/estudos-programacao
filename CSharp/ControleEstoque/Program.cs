using ControleEstoque.Models;
using System.Globalization;

Estoque estoque = new Estoque();
try
{
    string nomeProduto;
    do
    {
        Console.Write("Insira o nome do produto:");
        nomeProduto = Console.ReadLine();
    } while (String.IsNullOrEmpty(nomeProduto));

    estoque.EntrarNomeProduto(nomeProduto);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    int qtdTotal;
    do
    {
        Console.Write("Insira a quantidade atual do produto");
        qtdTotal = int.Parse(Console.ReadLine());
        if (qtdTotal == 0)
        {
            Console.WriteLine("O estoque deve ser maior que zero");
        }
    } while( qtdTotal == 0);
    
    estoque.ValidarEstoque(qtdTotal);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

Console.Write("Insira o estoque minimo: ");
int estoqueMinimo = int.Parse(Console.ReadLine());
estoque.EntrarEstoqueMinimo(estoqueMinimo);

Console.Write("Insira o estoque máximo: ");
int estoqueMaximo = int.Parse(Console.ReadLine());
estoque.EntrarEstoqueMaximo(estoqueMaximo);

Console.Write("Insira a quantidade vendida: ");
int qtd = int.Parse(Console.ReadLine());
estoque.EntrarQtdVendida(qtd);

if (estoque.QtdEstoque < estoque.QtdVendida)
{
    Console.Write("Erro: quantidade solicitada maior que o estoque disponível. ");
}

if (estoque.AbaixoDoMinimo)
{
    Console.WriteLine("Estoque crítico — realizar reposição imediatamente");
}
else if (estoque.AcimaMaximo)
{
    Console.WriteLine("Estoque acima do máximo — evitar novas compras");
}
else
{
    Console.WriteLine("Estoque adequado");
}