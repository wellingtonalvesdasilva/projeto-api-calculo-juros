using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Tests
{
    [TestClass]
    public class ExtensionsMethodTest
    {
        [TestMethod]
        public void GarantirQueOValorSejaTruncado()
        {
            const int qtdeDeCasasParaSerTruncada = 2;

            decimal valorEsperado = 100.92m;
            decimal valorASerTruncado = 100.92985m;

            Assert.AreEqual(valorEsperado, valorASerTruncado.TruncarValor(qtdeDeCasasParaSerTruncada));

            valorEsperado = 80.99m;
            valorASerTruncado = 80.999869m;

            Assert.AreEqual(valorEsperado, valorASerTruncado.TruncarValor(qtdeDeCasasParaSerTruncada));
        }
    }
}
