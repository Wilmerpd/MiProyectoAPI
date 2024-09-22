using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Data;
using MiProyectoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleViajeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetalleViajeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DetalleViaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleViaje>>> GetDetallesViaje()
        {
            return await _context.DetallesViaje.Include(d => d.Viaje).ToListAsync();
        }

        // GET: api/DetalleViaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleViaje>> GetDetalleViaje(int id)
        {
            var detalleViaje = await _context.DetallesViaje.Include(d => d.Viaje).FirstOrDefaultAsync(d => d.Id == id);

            if (detalleViaje == null)
            {
                return NotFound();
            }

            return detalleViaje;
        }

        // POST: api/DetalleViaje
        [HttpPost]
        public async Task<ActionResult<DetalleViaje>> PostDetalleViaje(DetalleViaje detalleViaje)
        {
            _context.DetallesViaje.Add(detalleViaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleViaje), new { id = detalleViaje.Id }, detalleViaje);
        }

        // PUT: api/DetalleViaje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleViaje(int id, DetalleViaje detalleViaje)
        {
            if (id != detalleViaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleViaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleViajeExists(id))
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

        // DELETE: api/DetalleViaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleViaje(int id)
        {
            var detalleViaje = await _context.DetallesViaje.FindAsync(id);
            if (detalleViaje == null)
            {
                return NotFound();
            }

            _context.DetallesViaje.Remove(detalleViaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleViajeExists(int id)
        {
            return _context.DetallesViaje.Any(e => e.Id == id);
        }
    }
}

