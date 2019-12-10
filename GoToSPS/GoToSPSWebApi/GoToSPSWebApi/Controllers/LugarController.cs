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
    public class LugarController : ControllerBase
    {
        private readonly GoToSPSContext _context;

        public LugarController(GoToSPSContext context)
        {
            _context = context;
        }

        // GET: api/Lugar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lugar>>> GetLugares()
        {
            return await _context.Lugares.ToListAsync();
        }

        // GET: api/Lugar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {
            var lugar = await _context.Lugares.FindAsync(id);

            if (lugar == null)
            {
                return NotFound();
            }

            return lugar;
        }

        // PUT: api/Lugar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugar(int id, Lugar lugar)
        {
            if (id != lugar.lugarId)
            {
                return BadRequest();
            }

            _context.Entry(lugar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugarExists(id))
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

        // POST: api/Lugar
        [HttpPost]
        public async Task<ActionResult<Lugar>> PostLugar(Lugar lugar)
        {
            _context.Lugares.Add(lugar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLugar", new { id = lugar.lugarId }, lugar);
        }

        // DELETE: api/Lugar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lugar>> DeleteLugar(int id)
        {
            var lugar = await _context.Lugares.FindAsync(id);
            if (lugar == null)
            {
                return NotFound();
            }

            _context.Lugares.Remove(lugar);
            await _context.SaveChangesAsync();

            return lugar;
        }

        private bool LugarExists(int id)
        {
            return _context.Lugares.Any(e => e.lugarId == id);
        }
    }
}
