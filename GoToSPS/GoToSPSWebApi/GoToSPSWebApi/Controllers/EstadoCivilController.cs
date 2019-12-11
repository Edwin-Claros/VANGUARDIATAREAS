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
    public class EstadoCivilController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public EstadoCivilController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCivil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCivil>>> GetEstadoCiviles()
        {
            return await _context.EstadoCiviles.ToListAsync();
        }

        // GET: api/EstadoCivil/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCivil>> GetEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadoCiviles.FindAsync(id);

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return estadoCivil;
        }

        // PUT: api/EstadoCivil/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCivil(int id, EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.estadoCivilId)
            {
                return BadRequest();
            }

            _context.Entry(estadoCivil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCivilExists(id))
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

        // POST: api/EstadoCivil
        [HttpPost]
        public async Task<ActionResult<EstadoCivil>> PostEstadoCivil(EstadoCivil estadoCivil)
        {
            _context.EstadoCiviles.Add(estadoCivil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCivil", new { id = estadoCivil.estadoCivilId }, estadoCivil);
        }

        // DELETE: api/EstadoCivil/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoCivil>> DeleteEstadoCivil(int id)
        {
            var estadoCivil = await _context.EstadoCiviles.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            _context.EstadoCiviles.Remove(estadoCivil);
            await _context.SaveChangesAsync();

            return estadoCivil;
        }

        private bool EstadoCivilExists(int id)
        {
            return _context.EstadoCiviles.Any(e => e.estadoCivilId == id);
        }
    }
}
