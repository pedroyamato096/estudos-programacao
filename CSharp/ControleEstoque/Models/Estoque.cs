using System.Globalization;
using System.Linq;
using ControleEstoque.Util;

namespace ControleEstoque.Models
{
    public class Estoque
    {
        public string NomeProduto { get; private set; }
        public int QtdEstoque {  get; private set; }
        public int EstoqueMinimo { get; private set;}
        public int EstoqueMaximo { get; private set; }

        public bool AbaixoDoMinimo { 
            get
            {
               return QtdEstoque < EstoqueMinimo;
            }
        }

        public bool AcimaMaximo
        {
            get
            {
                return QtdEstoque > EstoqueMaximo;
            }
        }
        public int QtdVendida { get; private set; }


        public string ValidarNomeProduto(string nome)
        {
            ValidacoesInput validar = new ValidacoesInput();
            string nomeProduto = validar.EntrarString(nome);
            return nomeProduto;
        }

        public void ValidarEstoque(int estoque)
        {
            if(estoque <= 0) {
                throw new ArgumentException("Erro: Estoque deve ser maior que zero.");
            }

            QtdEstoque = estoque;
        }

        public void EntrarNomeProduto(string nome)
        {
            string produto = ValidarNomeProduto(nome);
            NomeProduto = produto;
        }

        public void EntrarEstoqueMinimo( int entrada)
        {
            EstoqueMinimo = entrada;
        }

        public void EntrarEstoqueMaximo(int entrada)
        {
            EstoqueMaximo = entrada;
        }

        public void EntrarQtdVendida(int entrada)
        {
            QtdVendida = entrada;
        }
    }
}
