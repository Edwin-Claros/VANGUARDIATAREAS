using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitacora.API.Data;
using bitacora.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace bitacora.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController: ControllerBase {
        private readonly DataContext _context;

        public BitacoraController(DataContext context){
            _context=context;
        }

       [HttpGet]
        public async Task<IActionResult>GetBitacoras(){
            var bitacoras=await _context.Bitacoras.ToListAsync();
            return Ok(bitacoras);
        }

        [HttpGet("{tiempo}")]
       public async Task<ActionResult<Bitacora>> GetBitacora(DateTime tiempo)
        {
            var bitacora = await _context.Bitacoras.FirstOrDefaultAsync(q=> q.bitacoraFecha == tiempo);

            if(bitacora==null){
                return NotFound();
            }

            return bitacora;
        }

     [HttpGet("{id}/{id2}")]
        public IActionResult GetRango(DateTime id,DateTime id2)
        {
            var bitacora = _context.Bitacoras.Where(q=>q.bitacoraFecha >= id && q.bitacoraFecha <= id2).ToList();
            return Ok(bitacora);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitacora(int id, Bitacora bitacora)
        {
            if (id != bitacora.bitacoraId)      
            {
                return BadRequest();
            }

            _context.Entry(bitacora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitacoraExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Bitacora>> PostBitacora(Bitacora bitacora)
        {
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBitacora", new { tiempo = bitacora.bitacoraFecha }, bitacora);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Bitacora>> DeleteBitacora(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }

            _context.Bitacoras.Remove(bitacora);
            await _context.SaveChangesAsync();

            return bitacora;
        }

        private bool BitacoraExists(int id)
        {
            return _context.Bitacoras.Any(e => e.bitacoraId == id);
        }
    }
}