using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Repository;

namespace WebApplication4.Repository
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = Repository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = Repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Login))
            {
                return BadRequest("UserName and Login are required");
            }

            Repository.AddUser(user); // Исправлено на AddUser()
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                Repository.UpdateUser(user); // Исправлено на UpdateUser()
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                Repository.DeleteUser(id); // Исправлено на DeleteUser()
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}