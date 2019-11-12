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

    public class SumarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public SumarController(IUnitOfWork unitOfWork, DataContext context){
           _context = context;
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Sumar>>> GetSumars(){
         
         return await _unitOfWork.Sumar.GetAll(); 
        
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Sumar>> GetSumar(int id)
        {
            var sumar = await _unitOfWork.Sumar.GetById(id);


            if (sumar == null)
            {
                return NotFound();
            }
            return sumar;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutSumar(int id, Sumar sumar)
        {
            if (id != sumar.sumarlId)      
            {
                return BadRequest();
            }

            _context.Entry(sumar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SumarExists(id))
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
        public async Task<ActionResult<Sumar>> PostSumar(Sumar sumar)
        {
            await _unitOfWork.Sumar.Add(sumar);

            return CreatedAtAction("GetSumar", new { id = sumar.sumarlId }, sumar);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Sumar>> DeleteSumar(int id)
        {
            var sumar = await _context.Sumar.FindAsync(id);
            if (sumar == null)
            {
                return NotFound();
            }

            _context.Sumar.Remove(sumar);
            await _context.SaveChangesAsync();

            return sumar;
        }

        private bool SumarExists(int id)
        {
            return _context.Sumar.Any(e => e.sumarlId == id);
        }
    }
}
