using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using calculadora.API.Data;
using calculadora.API.Models;
using calculadora.API.Data.RepositoryUnitOfWork;

namespace calculadora.API.Controllers
{
    [Route("Calculadora/api/[controller]")]
    [ApiController]

    public class MultiplicarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public MultiplicarController(IUnitOfWork unitOfWork, DataContext context){
            _context = context;
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Multiplicar>>> GetMultiplicars(){
         
        return await _unitOfWork.Multiplicar.GetAll();

        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Multiplicar>> GetMultiplicar(int id)
        {
            var multiplicar = await _unitOfWork.Multiplicar.GetById(id);


            if (multiplicar == null)
            {
                return NotFound();
            }
            return multiplicar;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutMultiplicar(int id, Multiplicar multiplicar)
        {
            if (id != multiplicar.multiplicarlId)      
            {
                return BadRequest();
            }

            _context.Entry(multiplicar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiplicarExists(id))
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
        public async Task<ActionResult<Multiplicar>> PostMultiplicar(Multiplicar multiplicar)
        {
           await _unitOfWork.Multiplicar.Add(multiplicar);

            return CreatedAtAction("GetMultiplicar", new { id = multiplicar.multiplicarlId }, multiplicar);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Multiplicar>> DeleteMultiplicar(int id)
        {
            var multiplicar = await _context.Multiplicar.FindAsync(id);
            if (multiplicar == null)
            {
                return NotFound();
            }

            _context.Multiplicar.Remove(multiplicar);
            await _context.SaveChangesAsync();

            return multiplicar;
        }

        private bool MultiplicarExists(int id)
        {
            return _context.Multiplicar.Any(e => e.multiplicarlId == id);
        }
    }
}
