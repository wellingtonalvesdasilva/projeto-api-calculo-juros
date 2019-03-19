using Api.Interface;
using Api.Model;
using Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculaJurosServiceTest
    {
        public ICalculaJurosService _service { get; set; }

        public CalculaJurosServiceTest()
        {
            var config = new ConfiguracaoDaAplicacao
            {
                QtdeDeCasasDecimaisParaTruncar = 2,
                TaxaDeJuros = 0.01m,
                UrlDoGitHub = "UrlDoGit"
            };
            _service = new CalculaJurosService(config);
        }

        [TestMethod]
        public void CalcularJurosCompostoComTaxaDeUmPorCento()
        {
            decimal valorEsperado = 105.1m;
            decimal valorInicial = 100m;
            int qtdeDeMeses = 5;

            var resultado = _service.CalcularJurosCompostoPrefixado(valorInicial, qtdeDeMeses);
            Assert.AreEqual(valorEsperado, resultado);

            valorEsperado = 1051.01m;
            valorInicial = 1000m;

            resultado = _service.CalcularJurosCompostoPrefixado(valorInicial, qtdeDeMeses);
            Assert.AreEqual(valorEsperado, resultado);
        }

        [TestMethod]
        public void RetornarUrlDoGit()
        {
            string valorEsperado = "UrlDoGit";

            var resultado = _service.EnderecoDoCodigoFonte();
            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}
