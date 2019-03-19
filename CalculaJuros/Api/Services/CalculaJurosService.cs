using Api.Interface;
using Api.Model;
using System;
using Util;

namespace Api.Services
{
    /// <summary>
    /// Classe responsável por realizar o Cálculo de Juros Composto
    /// </summary>
    public class CalculaJurosService : ICalculaJurosService
    {
        /// <summary>
        /// Valor de configuração da aplicação
        /// </summary>
        public ConfiguracaoDaAplicacao _config { get; set; }

        /// <summary>
        /// Construtor do serviço CalculaJurosService
        /// </summary>
        /// <param name="config"></param>
        public CalculaJurosService(ConfiguracaoDaAplicacao config)
        {
            _config = config;
        }

        /// <summary>
        /// Retorna o cálculo do juros composto prefixado de uma taxa de juros
        /// </summary>
        /// <param name="valorInicial">Valor inicial do valor</param>
        /// <param name="meses">Qtde de meses</param>
        /// <returns></returns>
        public decimal CalcularJurosCompostoPrefixado(decimal valorInicial, int meses)
        {

            var taxaFinal = (1 + _config.TaxaDeJuros).ToDouble();
            var calculo = Math.Pow(taxaFinal, meses).ToDecimal();
            calculo = valorInicial * calculo;
            return calculo.TruncarValor(_config.QtdeDeCasasDecimaisParaTruncar);
        }

        /// <summary>
        /// Retorna o endereço do código fonte
        /// </summary>
        /// <returns></returns>
        public string EnderecoDoCodigoFonte()
        {
            return _config.UrlDoGitHub;
        }
    }
}
