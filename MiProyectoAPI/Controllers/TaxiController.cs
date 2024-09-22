using Microsoft.AspNetCore.Mvc;
using MiProyectoAPI.Data;
using MiProyectoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MiProyectoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaxiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Taxi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taxi>>> GetTaxis()
        {
            return await _context.Taxis.Include(t => t.Usuario).ToListAsync();
        }

        // GET: api/Taxi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taxi>> GetTaxi(int id)
        {
            var taxi = await _context.Taxis.Include(t => t.Usuario).FirstOrDefaultAsync(t => t.Id == id);

            if (taxi == null)
            {
                return NotFound();
            }

            return taxi;
        }

        // POST: api/Taxi
        [HttpPost]
        public async Task<ActionResult<Taxi>> PostTaxi(Taxi taxi)
        {
            _context.Taxis.Add(taxi);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaxi), new { id = taxi.Id }, taxi);
        }

        // PUT: api/Taxi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxi(int id, Taxi taxi)
        {
            if (id != taxi.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiExists(id))
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

        // DELETE: api/Taxi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxi(int id)
        {
            var taxi = await _context.Taxis.FindAsync(id);
            if (taxi == null)
            {
                return NotFound();
            }

            _context.Taxis.Remove(taxi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxiExists(int id)
        {
            return _context.Taxis.Any(e => e.Id == id);
        }
    }
}

