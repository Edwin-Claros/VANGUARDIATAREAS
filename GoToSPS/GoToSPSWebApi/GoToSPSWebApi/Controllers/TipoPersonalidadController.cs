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
    public class TipoPersonalidadController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public TipoPersonalidadController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/TipoPersonalidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPersonalidad>>> GetTipoPersonalidades()
        {
            return await _context.TipoPersonalidades.ToListAsync();
        }

        // GET: api/TipoPersonalidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPersonalidad>> GetTipoPersonalidad(int id)
        {
            var tipoPersonalidad = await _context.TipoPersonalidades.FindAsync(id);

            if (tipoPersonalidad == null)
            {
                return NotFound();
            }

            return tipoPersonalidad;
        }

        // PUT: api/TipoPersonalidad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPersonalidad(int id, TipoPersonalidad tipoPersonalidad)
        {
            if (id != tipoPersonalidad.tipoPersonalidadId)
            {
                return BadRequest();
            }

            _context.Entry(tipoPersonalidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPersonalidadExists(id))
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

        // POST: api/TipoPersonalidad
        [HttpPost]
        public async Task<ActionResult<TipoPersonalidad>> PostTipoPersonalidad(TipoPersonalidad tipoPersonalidad)
        {
            _context.TipoPersonalidades.Add(tipoPersonalidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPersonalidad", new { id = tipoPersonalidad.tipoPersonalidadId }, tipoPersonalidad);
        }

        // DELETE: api/TipoPersonalidad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoPersonalidad>> DeleteTipoPersonalidad(int id)
        {
            var tipoPersonalidad = await _context.TipoPersonalidades.FindAsync(id);
            if (tipoPersonalidad == null)
            {
                return NotFound();
            }

            _context.TipoPersonalidades.Remove(tipoPersonalidad);
            await _context.SaveChangesAsync();

            return tipoPersonalidad;
        }

        private bool TipoPersonalidadExists(int id)
        {
            return _context.TipoPersonalidades.Any(e => e.tipoPersonalidadId == id);
        }
    }
}
