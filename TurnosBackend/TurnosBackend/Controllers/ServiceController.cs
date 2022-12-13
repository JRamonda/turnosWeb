using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/services")]
    public class ServiceController : ControllerBase
    {
        // GET: api/services
        [HttpGet]
        [Route("")]
        public dynamic GetServices(string? name)
        {
            var Items = ServiceManager.Find(name);
            return Ok(new { Items = Items });
        }

        // GET: api/services/5
        [HttpGet("{id:int}")]
        public dynamic GetServiceById(int id)
        {
            var Item = ServiceManager.FindById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/services/5
        [HttpPut("{id:int}")]
        public dynamic PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest("El Id del servicio no coincide");
            }
            var itemToUpdate = ServiceManager.FindById(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Servicio con Id = {id} no se ha encontrado");
            }
            var itemUpdate = ServiceManager.Put(service);
            return Ok(new { Item = itemUpdate });
        }

        // DELETE: api/services/5
        [HttpDelete("{id:int}")]
        public dynamic DeleteServiceById(int id)
        {
            var Item = ServiceManager.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostService(Service service)
        {
            ServiceManager.Post(service);

            return CreatedAtAction(nameof(GetServices), new { id = service.Id }, service);
        }
    }
}