using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        // GET: api/clients
        [HttpGet]
        [Route("")]
        public dynamic GetClients(string? num_doc, int? id_type_doc)
        {
            var Items = ClientManager.Find(num_doc, id_type_doc);
            return Ok(new { Items = Items });
        }

        // GET: api/clients/5
        [HttpGet("{id:int}")]
        public dynamic GetClientById(int id)
        {
            var Item = ClientManager.FindById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/clients/5
        [HttpPut("{id:int}")]
        public dynamic PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest("El Id del cliente no coincide");
            }
            var itemToUpdate = ClientManager.FindById(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Cliente con Id = {id} no se ha encontrado");
            }
            var itemUpdate = ClientManager.Put(client);
            return Ok(new { Item = itemUpdate });
        }


        // DELETE: api/clients/5
        [HttpDelete("{id:int}")]
        public dynamic DeleteClientById(int id)
        {
            var Item = ClientManager.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostClient(Client client)
        {
            ClientManager.Post(client);

            return CreatedAtAction(nameof(GetClients), new { id = client.Id }, client);
        }
    }
}
