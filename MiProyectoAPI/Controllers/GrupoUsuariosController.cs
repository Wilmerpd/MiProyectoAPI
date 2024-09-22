using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Data;
using MiProyectoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoUsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GrupoUsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GrupoUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoUsuarios>>> GetGrupoUsuarios()
        {
            return await _context.GruposUsuarios.Include(g => g.Usuarios).ToListAsync();
        }

        // GET: api/GrupoUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoUsuarios>> GetGrupoUsuarios(int id)
        {
            var grupo = await _context.GruposUsuarios.Include(g => g.Usuarios).FirstOrDefaultAsync(g => g.Id == id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        // POST: api/GrupoUsuarios
        [HttpPost]
        public async Task<ActionResult<GrupoUsuarios>> PostGrupoUsuarios(GrupoUsuarios grupoUsuarios)
        {
            _context.GruposUsuarios.Add(grupoUsuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrupoUsuarios), new { id = grupoUsuarios.Id }, grupoUsuarios);
        }

        // PUT: api/GrupoUsuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoUsuarios(int id, GrupoUsuarios grupoUsuarios)
        {
            if (id != grupoUsuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoUsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/GrupoUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoUsuarios(int id)
        {
            var grupo = await _context.GruposUsuarios.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }

            _context.GruposUsuarios.Remove(grupo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrupoUsuariosExists(int id)
        {
            return _context.GruposUsuarios.Any(e => e.Id == id);
        }
    }
}

