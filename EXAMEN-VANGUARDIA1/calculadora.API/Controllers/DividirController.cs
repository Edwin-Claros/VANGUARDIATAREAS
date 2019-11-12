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

    public class DividirController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly DataContext _context;

        public DividirController(IUnitOfWork unitOfWork, DataContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dividir>>> GetDividirs()
        {
            return await _unitOfWork.Dividir.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dividir>> GetDividir(int id)
        {
            var dividir = await _unitOfWork.Dividir.GetById(id);


            if (dividir == null)
            {
                return NotFound();
            }
            return dividir;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDividir(int id, Dividir dividir)
        {
            if (id != dividir.dividirId)      
            {
                return BadRequest();
            }

            _context.Entry(dividir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DividirExists(id))
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
        public async Task<ActionResult<Dividir>> PostDividir(Dividir dividir)
        {
            await _unitOfWork.Dividir.Add(dividir);

            return CreatedAtAction("GetDividir", new { id = dividir.dividirId }, dividir);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Dividir>> DeleteDividir(int id)
        {
            var dividir = await _context.Dividir.FindAsync(id);
            if (dividir == null)
            {
                return NotFound();
            }

            _context.Dividir.Remove(dividir);
            await _context.SaveChangesAsync();

            return dividir;
        }

        private bool DividirExists(int id)
        {
            return _context.Dividir.Any(e => e.dividirId == id);
        }


    }
}
