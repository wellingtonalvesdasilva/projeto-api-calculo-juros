using Api.Interface;
using Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Controller responsável por realizar o cálculo de juros
    /// </summary>
    [Route("calculo")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        /// <summary>
        /// Interface do serviço
        /// </summary>
        public ICalculaJurosService _service { get; set; }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="service"></param>
        public CalculaJurosController(ICalculaJurosService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obter resultado do juros composto
        /// </summary>
        /// <param name="valorInicial">Valor inicial</param>
        /// <param name="meses">Qtde de meses</param>
        /// <returns></returns>
        [HttpGet("calculajuros")]
        public IActionResult CalculaJurosCompostoPrefixado(decimal valorInicial, int meses)
        {
            var resultado = _service.CalcularJurosCompostoPrefixado(valorInicial, meses);
            return Ok(resultado);
        }

        /// <summary>
        /// Retorna o endereço do GitHub do código fonte
        /// </summary>
        /// <returns></returns>
        [HttpGet("showmethecode")]
        public IActionResult EnderecoDoCodigoFonte()
        {
            var resultado = _service.EnderecoDoCodigoFonte();
            return Ok(resultado);
        }
    }
}