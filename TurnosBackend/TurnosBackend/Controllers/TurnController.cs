using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/turns")]
    public class TurnController : ControllerBase
    {
        // GET: api/turns
        [HttpGet]
        [Route("")]
        public dynamic GetTurns(DateTime? Date)
        {
            var Items = TurnManager.Find(Date);
            return Ok(new { Items = Items });
        }

        // GET: api/turns/5
        [HttpGet("{id:int}")]
        public dynamic GetTurnById(int id)
        {
            var Item = TurnManager.FindById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/tuns/5
        [HttpPut("{id:int}")]
        public dynamic PutTurn(int id, Turn turn)
        {
            if (id != turn.Id)
            {
                return BadRequest("El Id del turno no coincide");
            }
            var itemToUpdate = TurnManager.FindById(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Turno con Id = {id} no se ha encontrado");
            }
            var itemUpdate = TurnManager.Put(turn);
            return Ok(new { Item = itemUpdate });
        }

        // DELETE: api/turns/5
        [HttpDelete("{id:int}")]
        public dynamic DeleteTurnById(int id)
        {
            var Item = TurnManager.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostTurn(Turn turn)
        {
            TurnManager.Post(turn);

            return CreatedAtAction(nameof(GetTurns), new { id = turn.Id }, turn);
        }
    }
}
