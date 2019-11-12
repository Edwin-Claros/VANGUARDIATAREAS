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

    public class RaizController : Controller
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public RaizController(IUnitOfWork unitOfWork, DataContext context){
            _context = context;
            _unitOfWork = unitOfWork;
        }

       [HttpGet]
        public async Task<ActionResult<IEnumerable<Raiz>>> GetRaizs(){
          
         return await _unitOfWork.Raiz.GetAll();
        
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Raiz>> GetRaiz(int id)
        {
             var raiz = await _unitOfWork.Raiz.GetById(id);


            if (raiz == null)
            {
                return NotFound();
            }
            return raiz;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutRaiz(int id, Raiz raiz)
        {
            if (id != raiz.raizlId)      
            {
                return BadRequest();
            }

            _context.Entry(raiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaizExists(id))
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
        public async Task<ActionResult<Raiz>> PostRaiz(Raiz raiz)
        {
            await _unitOfWork.Raiz.Add(raiz);

            return CreatedAtAction("GetRaiz", new { id = raiz.raizlId }, raiz);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Raiz>> DeleteRaiz(int id)
        {
            var raiz = await _context.Raiz.FindAsync(id);
            if (raiz == null)
            {
                return NotFound();
            }

            _context.Raiz.Remove(raiz);
            await _context.SaveChangesAsync();

            return raiz;
        }

        private bool RaizExists(int id)
        {
            return _context.Raiz.Any(e => e.raizlId == id);
        }
    }
}
