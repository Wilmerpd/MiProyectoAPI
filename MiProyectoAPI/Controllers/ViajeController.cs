using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Data;
using MiProyectoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ViajeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Viaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
        {
            return await _context.Viajes.Include(v => v.Taxi).Include(v => v.Usuario).ToListAsync();
        }

        // GET: api/Viaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje>> GetViaje(int id)
        {
            var viaje = await _context.Viajes.Include(v => v.Taxi).Include(v => v.Usuario).FirstOrDefaultAsync(v => v.Id == id);

            if (viaje == null)
            {
                return NotFound();
            }

            return viaje;
        }

        // POST: api/Viaje
        [HttpPost]
        public async Task<ActionResult<Viaje>> PostViaje(Viaje viaje)
        {
            _context.Viajes.Add(viaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetViaje), new { id = viaje.Id }, viaje);
        }

        // PUT: api/Viaje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViaje(int id, Viaje viaje)
        {
            if (id != viaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(viaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeExists(id))
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

        // DELETE: api/Viaje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViaje(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }

            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.Id == id);
        }
    }
}
