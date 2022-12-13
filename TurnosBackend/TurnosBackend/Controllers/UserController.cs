using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        [Route("")]
        public dynamic GetUsers(int? IdProfile)
        {
            var Items = UserManager.Find(IdProfile);
            return Ok(new { Items = Items });
        }

        // GET: api/users/5
        [HttpGet("{id:int}")]
        public dynamic GetUserById(int id)
        {
            var Item = UserManager.FindById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/users/5
        [HttpPut("{id:int}")]
        public dynamic PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("El Id del usuario no coincide");
            }
            var itemToUpdate = UserManager.FindById(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Usuario con Id = {id} no se ha encontrado");
            }
            var itemUpdate = UserManager.Put(user);
            return Ok(new { Item = itemUpdate });
        }

        // DELETE: api/users/5
        [HttpDelete("{id:int}")]
        public dynamic DeleteUserById(int id)
        {
            var Item = UserManager.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostUser(User user)
        {
            UserManager.Post(user);

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}