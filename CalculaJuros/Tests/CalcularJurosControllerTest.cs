using Api.Controllers;
using Api.Interface;
using Api.Model;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalcularJurosControllerTest
    {
        public ICalculaJurosService _service { get; set; }

        public CalcularJurosControllerTest()
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
        public void GetApiCalculaJuros()
        {
            decimal valorEsperado = 105.1m;
            decimal valorInicial = 100m;
            int qtdeDeMeses = 5;

            var apiClient = new CalculaJurosController(_service);
            var resultado = apiClient.CalculaJurosCompostoPrefixado(valorInicial, qtdeDeMeses);

            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));

            ObjectResult objResultado = resultado as ObjectResult;

            Assert.AreEqual(200, objResultado.StatusCode);
            Assert.IsInstanceOfType(objResultado.Value, typeof(decimal));
            Assert.AreEqual(valorEsperado, objResultado.Value);
        }

        [TestMethod]
        public void GetApiShowMeTheCode()
        {
            string valorEsperado = "UrlDoGit";

            var apiClient = new CalculaJurosController(_service);
            var resultado = apiClient.EnderecoDoCodigoFonte();

            Assert.IsInstanceOfType(resultado, typeof(OkObjectResult));

            ObjectResult objResultado = resultado as ObjectResult;

            Assert.AreEqual(200, objResultado.StatusCode);
            Assert.IsInstanceOfType(objResultado.Value, typeof(string));
            Assert.AreEqual(valorEsperado, objResultado.Value);
        }
    }
}
