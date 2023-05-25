using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Citas;

namespace Agendarcitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Agendar_citasController : ControllerBase
    {
        private readonly DataContext _context;

        public Agendar_citasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Agendar_citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendar_citas>>> GetAgendar_citas()
        {
          if (_context.Agendar_citas == null)
          {
              return NotFound();
          }
            return await _context.Agendar_citas.Include(c=>c.cliente) .ToListAsync();
        }

        // GET: api/Agendar_citas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendar_citas>> GetAgendar_citas(int id)
        {
          if (_context.Agendar_citas == null)
          {
              return NotFound();
          }
            var agendar_citas = await _context.Agendar_citas.FindAsync(id);

            if (agendar_citas == null)
            {
                return NotFound();
            }

            return agendar_citas;
        }

        // PUT: api/Agendar_citas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendar_citas(int id, Agendar_citas agendar_citas)
        {
            if (id != agendar_citas.id)
            {
                return BadRequest();
            }

            _context.Entry(agendar_citas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Agendar_citasExists(id))
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

        // POST: api/Agendar_citas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agendar_citas>> PostAgendar_citas(Agendar_citas agendar_citas)
        {
          if (_context.Agendar_citas == null)
          {
              return Problem("Entity set 'DataContext.Agendar_citas'  is null.");
          }
            _context.Agendar_citas.Add(agendar_citas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendar_citas", new { id = agendar_citas.id }, agendar_citas);
        }

        // DELETE: api/Agendar_citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendar_citas(int id)
        {
            if (_context.Agendar_citas == null)
            {
                return NotFound();
            }
            var agendar_citas = await _context.Agendar_citas.FindAsync(id);
            if (agendar_citas == null)
            {
                return NotFound();
            }

            _context.Agendar_citas.Remove(agendar_citas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Agendar_citasExists(int id)
        {
            return (_context.Agendar_citas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
