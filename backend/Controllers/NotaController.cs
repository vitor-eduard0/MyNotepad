using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotepad.Classes;
using MyNotepad.Repository;

namespace MyNotepad.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotaController : Controller
    {
        private IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

        [HttpPost]
        [Authorize]
        [Route("inserir")]
        public IActionResult Inserir([FromBody] Nota nota)
        {
            NotaRepository notaRepository = new NotaRepository(_configuration.GetConnectionString("conexao"));
            notaRepository.inserir(nota);
            return Ok();
        }
    }
}
