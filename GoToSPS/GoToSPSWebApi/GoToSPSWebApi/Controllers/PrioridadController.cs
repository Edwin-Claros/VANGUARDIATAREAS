using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoToSPSWebApi.DataContext;
using GoToSPSWebApi.Models;

namespace GoToSPSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public PrioridadController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/Prioridad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridad>>> GetPrioridades()
        {
            return await _context.Prioridades.ToListAsync();
        }

        // GET: api/Prioridad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prioridad>> GetPrioridad(int id)
        {
            var prioridad = await _context.Prioridades.FindAsync(id);

            if (prioridad == null)
            {
                return NotFound();
            }

            return prioridad;
        }

        // PUT: api/Prioridad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridad(int id, Prioridad prioridad)
        {
            if (id != prioridad.prioridadId)
            {
                return BadRequest();
            }

            _context.Entry(prioridad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioridadExists(id))
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

        // POST: api/Prioridad
        [HttpPost]
        public async Task<ActionResult<Prioridad>> PostPrioridad(Prioridad prioridad)
        {
            _context.Prioridades.Add(prioridad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrioridad", new { id = prioridad.prioridadId }, prioridad);
        }

        // DELETE: api/Prioridad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prioridad>> DeletePrioridad(int id)
        {
            var prioridad = await _context.Prioridades.FindAsync(id);
            if (prioridad == null)
            {
                return NotFound();
            }

            _context.Prioridades.Remove(prioridad);
            await _context.SaveChangesAsync();

            return prioridad;
        }

        private bool PrioridadExists(int id)
        {
            return _context.Prioridades.Any(e => e.prioridadId == id);
        }
    }
}
