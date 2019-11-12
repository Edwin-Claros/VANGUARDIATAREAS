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

    public class ExponencialController: ControllerBase {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public ExponencialController(IUnitOfWork unitOfWork, DataContext context){
             _context = context;
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Exponencial>>> GetExponencials(){

          return await _unitOfWork.Exponencial.GetAll();
         
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Exponencial>> GetExponencial(int id)
        {
            var exponencial = await _unitOfWork.Exponencial.GetById(id);


            if (exponencial == null)
            {
                return NotFound();
            }
            return exponencial;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutExponencial(int id, Exponencial exponencial)
        {
            if (id != exponencial.exponencialId)      
            {
                return BadRequest();
            }

            _context.Entry(exponencial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExponencialExists(id))
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
        public async Task<ActionResult<Exponencial>> PostExponencial(Exponencial exponencial)
        {
            await _unitOfWork.Exponencial.Add(exponencial);
            return CreatedAtAction("GetExponencial", new { id = exponencial.exponencialId }, exponencial);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Exponencial>> DeleteExponencial(int id)
        {
            var exponencial = await _context.Exponencial.FindAsync(id);
            if (exponencial == null)
            {
                return NotFound();
            }

            _context.Exponencial.Remove(exponencial);
            await _context.SaveChangesAsync();

            return exponencial;
        }

        private bool ExponencialExists(int id)
        {
            return _context.Exponencial.Any(e => e.exponencialId == id);
        }
    }
}
