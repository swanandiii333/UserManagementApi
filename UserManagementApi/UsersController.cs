
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User
            {
                Id = 1,
                Name = "Aarav Sharma",
                Email = "aarav@example.com",
                Age = 22
            }
        };

        private static int _nextId = 2;

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(Users);
        }

        // GET: api/users/1
        [HttpGet("{id:int}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound(new { message = "User not found." });

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            user.Id = _nextId++;
            Users.Add(user);

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = user.Id },
                user
            );
        }

        // PUT: api/users/1
        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound(new { message = "User not found." });

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Age = updatedUser.Age;

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound(new { message = "User not found." });

            Users.Remove(user);

            return NoContent();
        }
    }
}
