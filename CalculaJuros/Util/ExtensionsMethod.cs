using System;

namespace Util
{
    public static class ExtensionsMethod
    {
        public static decimal TruncarValor(this decimal valor, int qtdeDeCasasDecimais)
        {
            const int qtdeDeNumerosDePontosFlutuantes = 10;

            var resultadoDaPotencia = Math.Pow(qtdeDeNumerosDePontosFlutuantes, qtdeDeCasasDecimais).ToDecimal();
            decimal valorTemp = Math.Truncate(resultadoDaPotencia * valor);
            return valorTemp / resultadoDaPotencia;
        }

        public static decimal ToDecimal(this double valor)
        {
            return Convert.ToDecimal(valor);
        }

        public static double ToDouble(this decimal valor)
        {
            return Convert.ToDouble(valor);
        }
    }
}
