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
    public class ItinerarioEncabezadoController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public ItinerarioEncabezadoController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/ItinerarioEncabezado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItinerarioEncabezado>>> GetItinerarioEncabezados()
        {
            return await _context.ItinerarioEncabezados.ToListAsync();
        }

        // GET: api/ItinerarioEncabezado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItinerarioEncabezado>> GetItinerarioEncabezado(int id)
        {
            var itinerarioEncabezado = await _context.ItinerarioEncabezados.FindAsync(id);

            if (itinerarioEncabezado == null)
            {
                return NotFound();
            }

            return itinerarioEncabezado;
        }

        // PUT: api/ItinerarioEncabezado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarioEncabezado(int id, ItinerarioEncabezado itinerarioEncabezado)
        {
            if (id != itinerarioEncabezado.itinerarioEncabezadoId)
            {
                return BadRequest();
            }

            _context.Entry(itinerarioEncabezado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioEncabezadoExists(id))
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

        // POST: api/ItinerarioEncabezado
        [HttpPost]
        public async Task<ActionResult<ItinerarioEncabezado>> PostItinerarioEncabezado(ItinerarioEncabezado itinerarioEncabezado)
        {
            _context.ItinerarioEncabezados.Add(itinerarioEncabezado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarioEncabezado", new { id = itinerarioEncabezado.itinerarioEncabezadoId }, itinerarioEncabezado);
        }

        // DELETE: api/ItinerarioEncabezado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItinerarioEncabezado>> DeleteItinerarioEncabezado(int id)
        {
            var itinerarioEncabezado = await _context.ItinerarioEncabezados.FindAsync(id);
            if (itinerarioEncabezado == null)
            {
                return NotFound();
            }

            _context.ItinerarioEncabezados.Remove(itinerarioEncabezado);
            await _context.SaveChangesAsync();

            return itinerarioEncabezado;
        }

        private bool ItinerarioEncabezadoExists(int id)
        {
            return _context.ItinerarioEncabezados.Any(e => e.itinerarioEncabezadoId == id);
        }
    }
}
