using apis_web_services_projeto_saber_mais.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

namespace apis_web_services_projeto_saber_mais.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult> Create(UsuarioDto usuario)
        {
            Usuario novoUsuario = new Usuario()
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password),
                Cpf = usuario.Cpf,
                Descricao = usuario.Descricao
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = novoUsuario.Id}, novoUsuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Agendamentos) // Inclui os agendamentos onde o usuário é aluno
                .Include(u => u.AvaliacoesFeitas) // Inclui as avaliações feitas pelo usuário
                .FirstOrDefaultAsync(c => c.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            GerarLinks(usuario);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UsuarioDto usuario)
        {
            if (id != usuario.Id) return BadRequest();

            var usuarioDb = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (usuarioDb == null) return NotFound();

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            usuarioDb.Cpf = usuario.Cpf;    
            usuarioDb.Descricao = usuario.Descricao;

            _context.Usuarios.Update(usuarioDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPost("Authenticate")]
        //public async Task<ActionResult> Authenticate(AuthenticateDto model)
        //{
        //    var usuarioDb = await _context.Usuarios.FindAsync(model.Id);

        //    if (usuarioDb == null || !BCrypt.Net.BCrypt.Verify(model.Password, usuarioDb.Password))
        //        return Unauthorized(new { message = "ID ou senha inválidos" });

        //    var jwt = "xxx";
            
        //    return Ok(new { jwtToken = jwt });
        //}

        private void GerarLinks(Usuario usuario)
        {
            usuario.Links.Add(new LinkDto(usuario.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            usuario.Links.Add(new LinkDto(usuario.Id, Url.ActionLink(), rel: "update_usuario", metodo: "PUT"));
            usuario.Links.Add(new LinkDto(usuario.Id, Url.ActionLink(), rel: "delete_usuario", metodo: "DELETE"));
        }

    }
}
