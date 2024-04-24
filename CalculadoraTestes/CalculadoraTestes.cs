using System;
using Xunit;

namespace CalculadoraTestes
{
    public class CalculadoraTestes
    {
        private readonly Calculadora.Services.Calculadora _calculadora;

        public CalculadoraTestes()
        {
            _calculadora = new Calculadora.Services.Calculadora(DateTime.Now);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void Somar_DoisNumerosInteiros_NumeroInteiroResultadoCorretoDaSoma(int operando1, int operando2, int resultadoEsperado)
        {
            //Act
            int resultado = _calculadora.Somar(operando1, operando2);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(20, 2, 18)]
        [InlineData(5, 5, 0)]
        public void Subtrair_DoisNumerosInteiros_NumeroInteiroResultadoCorretoDaSubtracao(int minuendo, int subtraendo, int resultadoEsperado)
        {
            //Act
            int resultado = _calculadora.Subtrair(minuendo, subtraendo);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(3, 2, 6)]
        [InlineData(4, 5, 20)]
        public void Multiplicar_DoisNumerosInteiros_NumeroInteiroResultadoCorretoDaMultiplicacao(int fator1, int fator2, int resultadoEsperado)
        {
            //Act
            int resultado = _calculadora.Multiplicar(fator1, fator2);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(20, 4, 5)]
        public void Dividir_DoisNumerosInteiros_NumeroInteiroResultadoCorretoDaDivisao(int dividendo, int divisor, int resultadoEsperado)
        {
            //Act
            int resultado = _calculadora.Dividir(dividendo, divisor);

            //Assert
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void Dividir_DoisNumerosInteirosPorZero_RetornarExecao()
        {
            //Arrange
            int dividendo = 3;
            int divisor = 0;

            //Act / Assert
            Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(dividendo, divisor));
        }

        [Fact]
        public void Historico_VerificarSeAListaContem3Itens_RetornaListaCom3Itens()
        {
            //Arrange
            int resultadoEsperado = 3;
            _calculadora.Somar(1, 2);
            _calculadora.Somar(2, 8);
            _calculadora.Somar(3, 7);
            _calculadora.Somar(4, 1);

            //Act
            var lista = _calculadora.Historico();

            //Assert
            Assert.NotEmpty(lista);
            Assert.Equal(resultadoEsperado, lista.Count);
        }

    }
}
