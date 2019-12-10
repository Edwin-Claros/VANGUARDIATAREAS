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
    public class ItinerarioDetalleController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public ItinerarioDetalleController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/ItinerarioDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItinerarioDetalle>>> GetItinerarioDetalles()
        {
            return await _context.ItinerarioDetalles.ToListAsync();
        }

        // GET: api/ItinerarioDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItinerarioDetalle>> GetItinerarioDetalle(int id)
        {
            var itinerarioDetalle = await _context.ItinerarioDetalles.FindAsync(id);

            if (itinerarioDetalle == null)
            {
                return NotFound();
            }

            return itinerarioDetalle;
        }

        // PUT: api/ItinerarioDetalle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerarioDetalle(int id, ItinerarioDetalle itinerarioDetalle)
        {
            if (id != itinerarioDetalle.itinerarioDetalleId)
            {
                return BadRequest();
            }

            _context.Entry(itinerarioDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioDetalleExists(id))
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

        // POST: api/ItinerarioDetalle
        [HttpPost]
        public async Task<ActionResult<ItinerarioDetalle>> PostItinerarioDetalle(ItinerarioDetalle itinerarioDetalle)
        {
            _context.ItinerarioDetalles.Add(itinerarioDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItinerarioDetalle", new { id = itinerarioDetalle.itinerarioDetalleId }, itinerarioDetalle);
        }

        // DELETE: api/ItinerarioDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItinerarioDetalle>> DeleteItinerarioDetalle(int id)
        {
            var itinerarioDetalle = await _context.ItinerarioDetalles.FindAsync(id);
            if (itinerarioDetalle == null)
            {
                return NotFound();
            }

            _context.ItinerarioDetalles.Remove(itinerarioDetalle);
            await _context.SaveChangesAsync();

            return itinerarioDetalle;
        }

        private bool ItinerarioDetalleExists(int id)
        {
            return _context.ItinerarioDetalles.Any(e => e.itinerarioDetalleId == id);
        }
    }
}
