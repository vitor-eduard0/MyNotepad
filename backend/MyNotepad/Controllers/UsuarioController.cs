using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotepad.Classes;
using MyNotepad.Repository;

namespace MyNotepad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

        [HttpPost]
        [AllowAnonymous]
        [Route("logar")]
        public IActionResult Logar([FromBody] Usuario usuario)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository(_configuration.GetConnectionString("conexao"));
            Usuario? usuarioBuscado = usuarioRepository.listar(usuario).FirstOrDefault();

            if(usuarioBuscado == null)
                return NotFound("Usuário e/ou senha incorreto(s).");

            TokenAuthentication tokenAuthentication = new TokenAuthentication(_configuration);
            usuarioBuscado.token = tokenAuthentication.gerarToken(usuarioBuscado);

            return Ok(usuarioBuscado);

        }
    }
}
