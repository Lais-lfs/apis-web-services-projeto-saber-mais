using apis_web_services_projeto_saber_mais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apis_web_services_projeto_saber_mais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Essa configuração de contexto é necessária para que o controller consiga se comunicar com o banco de dados
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/Usuarios; busca todos os usuários cadastrados no banco de dados
        public async Task<ActionResult> GetAll()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = usuario.Id}, usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            var usuarioDb = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (usuarioDb == null) return NotFound();

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
