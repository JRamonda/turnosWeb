using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/typeDocs")]
    public class TypeDocController : ControllerBase
    {
        // GET: api/typeDocs
        [HttpGet]
        [Route("")]
        public dynamic GetTypeDocs(string? name)
        {
            var Items = TypeDocManager.Find(name);
            return Ok(new { Items = Items });
        }

        // GET: api/typeDocs/5
        [HttpGet("{id:int}")]
        public dynamic GetTypeDocById(int id)
        {
            var Item = TypeDocManager.FindById(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/typeDocs/5
        [HttpPut("{id:int}")]
        public dynamic PutTypeDoc(int id, TypeDoc typeDocs)
        {
            if (id != typeDocs.Id)
            {
                return BadRequest("El Id del tipo documento no coincide");
            }
            var itemToUpdate = TypeDocManager.FindById(id);
            if (itemToUpdate == null)
            {
                return NotFound($"Tipo Documento con Id = {id} no se ha encontrado");
            }
            var itemUpdate = TypeDocManager.Put(typeDocs);
            return Ok(new { Item = itemUpdate });
        }

        // DELETE: api/typeDocs/5
        [HttpDelete("{id:int}")]
        public dynamic DeleteTypeDocById(int id)
        {
            var Item = TypeDocManager.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostTypeDoc(TypeDoc typeDoc)
        {
            TypeDocManager.Post(typeDoc);

            return CreatedAtAction(nameof(GetTypeDocs), new { id = typeDoc.Id }, typeDoc);
        }
    }
}