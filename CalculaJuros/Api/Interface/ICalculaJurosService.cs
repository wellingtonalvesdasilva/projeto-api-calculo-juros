using Api.Model;

namespace Api.Interface
{
    /// <summary>
    /// Interface de service do cálcula juros
    /// </summary>
    public interface ICalculaJurosService
    {
        /// <summary>
        /// Calcular juros composto prefixado
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="qtdeDeMeses"></param>
        /// <returns></returns>
        decimal CalcularJurosCompostoPrefixado(decimal valorInicial, int qtdeDeMeses);

        /// <summary>
        /// Retornar o endereço do código fonte
        /// </summary>
        /// <returns></returns>
        string EnderecoDoCodigoFonte();
    }
}
