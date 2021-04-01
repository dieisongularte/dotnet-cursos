using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DIO.Cursos.Models.Usuarios;
using DIO.Cursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using DIO.Cursos.Filters;

namespace DIO.Cursos.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            }*/
            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            return Created("", registroViewModelInput);
        }
    }
}
