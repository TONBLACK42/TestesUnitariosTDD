using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Services
{
    public class Calculadora
    {
        private readonly List<string> _historico;
        private readonly DateTime _dataCalculoEfetuado;

        public Calculadora(DateTime dataCalculoEfetuado)
        {
            _historico = new List<string>();
            _dataCalculoEfetuado = dataCalculoEfetuado;
        }
        public int Somar(int operando1, int operando2)
        {
            int soma = operando1 + operando2;
            RegistrarHistorico("Soma", soma);
            return soma;
        }

        public int Subtrair(int minuendo, int subtraendo)
        {
            int diferenca = minuendo - subtraendo;
            RegistrarHistorico("Diferença", diferenca);
            return diferenca;
        }

        public int Multiplicar(int fator1, int fator2)
        {
            int produto = fator1 * fator2;
            RegistrarHistorico("Produto", produto);
            return produto;
        }

        public int Dividir(int dividendo, int divisor)
        {
            int quociente = dividendo / divisor;
            RegistrarHistorico("Quociente", quociente);
            return quociente;
        }

        public List<string> Historico()
        {
            _historico.RemoveRange(3, _historico.Count - 3);
            return _historico;
        }

        private void RegistrarHistorico(string nomeResultado, int resultado)
        {
            _historico.Insert(0, $"O {nomeResultado} é: {resultado}");
        }
    }
}
