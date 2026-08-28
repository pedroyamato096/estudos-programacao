
using System.Linq;
namespace ControleEstoque.Util
{
    public class ValidacoesInput
    {
        public string EntrarString(string input)
        {
            string entrada = input;
            if (String.IsNullOrEmpty(entrada))
            {
                throw new ArgumentException("Erro: O campo não pode ser nulo ou vazio.");
            }

            if (entrada.Any(char.IsDigit))
            {
                throw new ArgumentException("Erro: o campo deve conter apenas letras.");
            }

            return entrada;
        }
    }
}
