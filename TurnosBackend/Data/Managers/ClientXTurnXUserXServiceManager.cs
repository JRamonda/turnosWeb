using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class ClientXTurnXUserXServiceManager
    {
        public async static Task<IEnumerable<object>> Find(int? idClient, int? idTurn, int? idUser, int? idService)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                var consult = db.ClientsXTurnsXUsersXServices
                    .Select(c => new
                    {
                        c.IdClient,
                        c.IdTurn,
                        c.IdUser,
                        c.IdService,
                        Client = c.Client,
                        Turn = c.Turn,
                        User = c.User,
                        Service = c.Service
                    });

                if (idClient != null)
                    consult = consult.Where(x => x.IdClient == idClient);
                if (idTurn != null)
                    consult = consult.Where(x => x.IdTurn == idTurn);
                if (idUser != null)
                    consult = consult.Where(x => x.IdUser == idUser);
                if (idService != null)
                    consult = consult.Where(x => x.IdService == idService);

                return consult.OrderBy(x => x.Turn.Date).ToList();
            }
        }

        public async static Task<object> FindById(int idClient, int idTurn, int idUser, int idService)
        {
            using (BdTurnosContext db = new BdTurnosContext()) //el using asegura el db.dispose() que libera la conexion de la base
            {
                return db.ClientsXTurnsXUsersXServices
                    .Select(c => new
                    {
                        c.IdClient,
                        c.IdTurn,
                        c.IdUser,
                        c.IdService,
                        Client = c.Client,
                        Turn = c.Turn,
                        User = c.User,
                        Service = c.Service
                    }).Where(x => x.IdClient == idClient && x.IdUser == idUser && x.IdTurn == idTurn && x.IdService == idService).FirstOrDefault();
                //return db.ClientsXTurnsXUsers.Where(x => x.IdClient == Id).FirstOrDefault();
                //return db.Articulos.Find(sId);
            }
        }

        public static ClientXTurnXUserXService Put(ClientXTurnXUserXService Item)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    var result = db.ClientsXTurnsXUsersXServices.FirstOrDefault(x => x.IdClient == Item.IdClient && x.IdUser == Item.IdUser && x.IdTurn == Item.IdTurn && x.IdService == Item.IdService);

                    if (result != null)
                    {
                        result.IdClient = Item.IdClient;
                        result.IdUser = Item.IdUser;
                        result.IdTurn = Item.IdTurn;
                        result.IdService = Item.IdService;

                        db.SaveChanges();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    // loguearlo y devolver msj generico…
                    throw new ApplicationException("En estos momentos no podemos procesar su solicitud, intente nuevamente más tarde (ref xxxx)");
                }
            }
        }

        public static void Post(ClientXTurnXUserXService Item)
        {
            // validar campos
            string erroresValidacion = "";
            if (Item.IdClient == null)
                erroresValidacion += "Id Cliente es un dato requerido; ";
            if (Item.IdTurn == null)
                erroresValidacion += "Id Turno es un dato requerido; ";
            if (Item.IdUser == null)
                erroresValidacion += "Id Usuario es un dato requerido; ";
            if (Item.IdService == null)
                erroresValidacion += "Id Servicio es un dato requerido; ";
            if (!string.IsNullOrEmpty(erroresValidacion))
                throw new ApplicationException(erroresValidacion);

            // grabar registro
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    db.ClientsXTurnsXUsersXServices.Add(Item);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // loguearlo y devolver msj generico…
                    throw new ApplicationException("En estos momentos no podemos procesar su solicitud, intente nuevamente más tarde (ref xxxx)");
                }
            }
        }

        public static ClientXTurnXUserXService Delete(int idClient, int idTurn, int idUser, int idService)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                // baja fisica.
                ClientXTurnXUserXService clientXTurnXUserXService = db.ClientsXTurnsXUsersXServices.Find(idClient, idTurn, idUser, idService);
                if (clientXTurnXUserXService == null)
                {
                    return null;
                }
                db.ClientsXTurnsXUsersXServices.Remove(clientXTurnXUserXService);
                db.SaveChanges();
                return clientXTurnXUserXService;
            }
        }
    }
}
