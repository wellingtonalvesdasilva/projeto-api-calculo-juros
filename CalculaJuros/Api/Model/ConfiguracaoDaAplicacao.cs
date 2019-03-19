namespace Api.Model
{
    /// <summary>
    /// Classe que mantém as informações da Aplicação
    /// </summary>
    public class ConfiguracaoDaAplicacao
    {
        /// <summary>
        /// Url do GitHub
        /// </summary>
        public string UrlDoGitHub { get; set; }

        /// <summary>
        /// Taxa de juros prefixada do sistema
        /// </summary>
        public decimal TaxaDeJuros { get; set; }

        /// <summary>
        /// Qtde de casas decimais prefixada do sistema para truncar
        /// </summary>
        public int QtdeDeCasasDecimaisParaTruncar { get; set; }
    }
}
