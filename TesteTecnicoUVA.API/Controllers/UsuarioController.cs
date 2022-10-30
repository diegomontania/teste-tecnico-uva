using Microsoft.AspNetCore.Mvc;
using TesteTecnicoUVA.API.Models;

namespace TesteTecnicoUVA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UsuarioController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("TodosUsuarios")]
        public async Task<ActionResult<List<Usuario>>> TodosUsuarios()
        {
            //retorna lista assincrona
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> RetornaUsuario(int id)
        {
            var usuarioEncontrado = await _context.Usuarios.FindAsync(id);

            //se não encontrar usuario retorne null ou retorne o usuario encontrado
            if (usuarioEncontrado == null)
                return BadRequest("Usuário não encontrado para a ID fornecida.");
            else
                return Ok(usuarioEncontrado);
        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> NovoUsuario(Usuario usuario)
        {
            //adiciona usuario salva modificacoes no banco assincrona
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> AtualizaUsuario(Usuario usuarioParametro)
        {
            var usuarioEncontrado = await _context.Usuarios.FindAsync(usuarioParametro.Id);

            if (usuarioEncontrado == null)
                return BadRequest("Usuário não encontrado para a ID fornecida.");
            else
                //recebe as informacoes do objeto passado por parametro, no registro encontrado do banco
                usuarioEncontrado.NomeCompleto = usuarioParametro.NomeCompleto;
                usuarioEncontrado.Cpf = usuarioParametro.Cpf;
                usuarioEncontrado.Telefone = usuarioParametro.Telefone;
                usuarioEncontrado.TelefoneCelular = usuarioParametro.TelefoneCelular;
                usuarioEncontrado.Email = usuarioParametro.Email;
                usuarioEncontrado.DataCriacao = usuarioParametro.DataCriacao;
                usuarioEncontrado.Ativo = usuarioParametro.Ativo;

            await _context.SaveChangesAsync();
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuario>>> DeletaUsuario(int id)
        {
            var usuarioEncontrado = await _context.Usuarios.FindAsync(id);

            if (usuarioEncontrado == null)
                return BadRequest("Usuário não encontrado para a ID fornecida.");
            else
                _context.Usuarios.Remove(usuarioEncontrado);
                await _context.SaveChangesAsync();

            return Ok(await _context.Usuarios.ToListAsync());
        }
    }
}
