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

    public class RestarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public RestarController(IUnitOfWork unitOfWork, DataContext context){
            _context = context;
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Restar>>> GetRestars(){
            
            return await _unitOfWork.Restar.GetAll();         
        
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Restar>> GetRestar(int id)
        {
           var restar = await _unitOfWork.Restar.GetById(id);


            if (restar == null)
            {
                return NotFound();
            }
            return restar;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutRestar(int id, Restar restar)
        {
            if (id != restar.restarlId)      
            {
                return BadRequest();
            }

            _context.Entry(restar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestarExists(id))
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
        public async Task<ActionResult<Restar>> PostRestar(Restar restar)
        {
            await _unitOfWork.Restar.Add(restar);
            return CreatedAtAction("GetRestar", new { id = restar.restarlId }, restar);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Restar>> DeleteRestar(int id)
        {
            var restar = await _context.Restar.FindAsync(id);
            if (restar == null)
            {
                return NotFound();
            }

            _context.Restar.Remove(restar);
            await _context.SaveChangesAsync();

            return restar;
        }

        private bool RestarExists(int id)
        {
            return _context.Restar.Any(e => e.restarlId == id);
        }
    }
}
