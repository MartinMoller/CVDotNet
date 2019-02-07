using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVDotNet.Models;
using CVDotNet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace CVDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly cvDBContext _context;
        private readonly IUserRepo _repo;

        public UserController(cvDBContext context, IUserRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        // GET api/user
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        // GET api/user/id
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUser(int id)
        {
            return Ok(_context.User.Single(u => u.Id.Equals(id)));
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}