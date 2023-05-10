using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app.Models;
using app.Models.Response;
using app.services;

namespace app.Controllers

{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly UserServices _userService;

        public UserController(DbContext context)
        {
            _context = context;
            _userService = new UserServices(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Set<User>()
                .Select(u => new User
                {
                    Id = u.Id,
                    Email = u.Email,
                    Username = u.Username,
                    Tel = u.Tel,
                    Role = u.Role,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();

            var response = new UserMessageResponse
            {
                Message = "Success",
                Data = users
            };

            return new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Set<User>().SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var response = new UserMessageResponse
            {
                Message = "Success",
                Data = (IEnumerable<User>)user
            };

            return new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;

            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, User updatedUser)
        {
            if (updatedUser == null || id == null)
            {
                return BadRequest();
            }

            var numId = int.Parse(id);
            var existingUser = await _context.Set<User>().FindAsync(numId);

            if (existingUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(existingUser).State = EntityState.Detached;

            if (await TryUpdateModelAsync(existingUser, "", u => u.Username))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetUserById), new { id = updatedUser.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_userService.UserExists(numId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Set<User>().SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Set<User>().Remove(user);
            await _context.SaveChangesAsync();

            var response = new UserMessageResponse
            {
                Message = "Success"
            };

            return new JsonResult(response)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

    }
}
