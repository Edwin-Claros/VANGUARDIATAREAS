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
    public class TipoAmbienteController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public TipoAmbienteController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/TipoAmbiente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAmbiente>>> GetTipoAmbientes()
        {
            return await _context.TipoAmbientes.ToListAsync();
        }

        // GET: api/TipoAmbiente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAmbiente>> GetTipoAmbiente(int id)
        {
            var tipoAmbiente = await _context.TipoAmbientes.FindAsync(id);

            if (tipoAmbiente == null)
            {
                return NotFound();
            }

            return tipoAmbiente;
        }

        // PUT: api/TipoAmbiente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAmbiente(int id, TipoAmbiente tipoAmbiente)
        {
            if (id != tipoAmbiente.tipoAmbienteId)
            {
                return BadRequest();
            }

            _context.Entry(tipoAmbiente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAmbienteExists(id))
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

        // POST: api/TipoAmbiente
        [HttpPost]
        public async Task<ActionResult<TipoAmbiente>> PostTipoAmbiente(TipoAmbiente tipoAmbiente)
        {
            _context.TipoAmbientes.Add(tipoAmbiente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoAmbiente", new { id = tipoAmbiente.tipoAmbienteId }, tipoAmbiente);
        }

        // DELETE: api/TipoAmbiente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoAmbiente>> DeleteTipoAmbiente(int id)
        {
            var tipoAmbiente = await _context.TipoAmbientes.FindAsync(id);
            if (tipoAmbiente == null)
            {
                return NotFound();
            }

            _context.TipoAmbientes.Remove(tipoAmbiente);
            await _context.SaveChangesAsync();

            return tipoAmbiente;
        }

        private bool TipoAmbienteExists(int id)
        {
            return _context.TipoAmbientes.Any(e => e.tipoAmbienteId == id);
        }
    }
}
