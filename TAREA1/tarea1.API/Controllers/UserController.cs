using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tarea1.API.DataContext;
using tarea1.API.Models;

namespace tarea1.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    { 
        private readonly DataContextUser _context;

        public UserController(DataContextUser context) 
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult>GetUsers()
        {
            var Users =await _context.Users.ToListAsync();
            return Ok(Users);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<User>>GetUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.userDNI==id);
            if (user==null)
            {
                return BadRequest("No Encontrado");
            }

            return user;
        }   

    }
}