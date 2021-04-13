using DIO.Cursos.Business.Entities;
using DIO.Cursos.Business.Repositories;
using DIO.Cursos.Configurations;
using DIO.Cursos.Filters;
using DIO.Cursos.Models;
using DIO.Cursos.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DIO.Cursos.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;        
        private readonly IAuthenticationService _authenticationService;

        public UsuarioController(
            IUsuarioRepository usuarioRepository, 
            IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            /*if (usuario.Senha != loginViewModel.Senha.GerarSenhaCriptografada())
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }*/

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };
           
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new { 
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            /*var migracoesPendentes = _context.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
            {
                _context.Database.Migrate();
            }*/

            var usuario = new Usuario();
            usuario.Login = registroViewModelInput.Login;
            usuario.Senha = registroViewModelInput.Senha;
            usuario.Email = registroViewModelInput.Email;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registroViewModelInput);
        }
    }
}
