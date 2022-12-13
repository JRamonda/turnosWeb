using Data.Managers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace TurnosBackend.Controllers
{
    [ApiController]
    [Route("api/clientxturnxuserxservice")]
    public class ClientXTurnXUserXServiceController : ControllerBase
    {
        // GET: api/clientxturnxuserxservice
        [HttpGet]
        [Route("")]
        public dynamic GetClientsXTurnsXUsersXServices(int? idClient, int? idTurn, int? idUser, int? idService)
        {
            var Items = ClientXTurnXUserXServiceManager.Find(idClient, idTurn, idUser, idService);
            return Ok(new { Items = Items });
        }

        // GET: api/clientxturnxuserxservice/5-5-5-5
        [HttpGet("{idClient:int}-{idTurn:int}-{idUser:int}-{idService:int}")]
        public dynamic GetClientXTurnXUserById(int idClient, int idTurn, int idUser, int idService)
        {
            var Item = ClientXTurnXUserXServiceManager.FindById(idClient, idTurn, idUser, idService);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(new { Item = Item });
        }

        // PUT: api/clientxturnxuserxservice/5-5-5-5
        [HttpPut("{idClient:int}-{idTurn:int}-{idUser:int}-{idService:int}")]
        public dynamic PutClientXTurnXUser(int idClient, int idTurn, int idUser, int idService, ClientXTurnXUserXService clientsXTurnsXUserXService)
        {
            if (idClient != clientsXTurnsXUserXService.IdClient && idUser != clientsXTurnsXUserXService.IdUser && idTurn != clientsXTurnsXUserXService.IdTurn && clientsXTurnsXUserXService.IdService != idService)
            {
                return BadRequest("El Id del ClientXTurnXUserXService no coincide");
            }
            var itemToUpdate = ClientXTurnXUserXServiceManager.FindById(idClient, idTurn, idUser, idService);
            if (itemToUpdate == null)
            {
                return NotFound($"ClientXTurnXUserXService con IdCliente = {idClient}, IdUsuario = {idUser}, IdTurno = {idTurn}, IdService = {idService} no se ha encontrado");
            }
            var itemUpdate = ClientXTurnXUserXServiceManager.Put(clientsXTurnsXUserXService);
            return Ok(new { Item = itemUpdate });
        }

        // DELETE: api/clientxturnxuserxservice/5-5-5-5
        [HttpDelete("{idClient:int}-{idTurn:int}-{idUser:int}-{idService:int}")]
        public dynamic DeleteClientXTurnXUserById(int idClient, int idTurn, int idUser, int idService)
        {
            var Item = ClientXTurnXUserXServiceManager.Delete(idClient, idTurn, idUser, idService);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public dynamic PostClientXTurnXUser(ClientXTurnXUserXService clientsXTurnsXUserXService)
        {
            ClientXTurnXUserXServiceManager.Post(clientsXTurnsXUserXService);

            return CreatedAtAction(nameof(GetClientsXTurnsXUsersXServices), new { id = clientsXTurnsXUserXService.IdClient, clientsXTurnsXUserXService.IdTurn, clientsXTurnsXUserXService.IdUser, clientsXTurnsXUserXService.IdService }, clientsXTurnsXUserXService);
        }
    }
}