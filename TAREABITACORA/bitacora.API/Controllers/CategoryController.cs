using System.Linq;
using System.Threading.Tasks;
using bitacora.API.Data;
using bitacora.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CategoryController: ControllerBase {
        private readonly DataContext _context;

        public CategoryController(DataContext context){
            _context=context;
        }

       
        public async Task<IActionResult>GetCategies(){
            var categories=await _context.Categories.ToListAsync();
            return Ok(categories);
        
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(q=> q.categoryId == id);
            return Ok(category);
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoy(int id, Category category)
        {
            if (id != category.categoryId)      
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategies", new { id = category.categoryId }, category);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.categoryId == id);
        }
    }
}