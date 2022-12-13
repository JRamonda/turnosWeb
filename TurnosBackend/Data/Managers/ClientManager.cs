using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Data.Managers
{
    public class ClientManager
    {
        public async static Task<IEnumerable<object>> Find(string? num_doc, int? id_type_doc)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                var consult = db.Clients
                    .Select(c => new
                    {
                        c.Id,
                        c.NumDoc,
                        c.NumPhone,
                        c.FirstName,
                        c.LastName,
                        c.IdTypeDoc,
                        TypeDoc = c.TypeDoc
                    });

                if (id_type_doc != null)
                    consult = consult.Where(x => x.NumDoc == num_doc && x.IdTypeDoc == id_type_doc);

                return consult.OrderBy(x => x.FirstName).ToList();
            }
        }

        public async static Task<object> FindById(int Id)
        {
            using (BdTurnosContext db = new BdTurnosContext()) //el using asegura el db.dispose() que libera la conexion de la base
            {
                //return db.Clients.Include(x => x.Type_Doc).Where(x => x.Id == Id).FirstOrDefault();
                return db.Clients
                    .Select(c => new
                    {
                        c.Id,
                        c.NumDoc,
                        c.NumPhone,
                        c.FirstName,
                        c.LastName,
                        c.IdTypeDoc,
                        TypeDoc = c.TypeDoc
                    }).Where(x => x.Id == Id).FirstOrDefault();
                //return db.Clients.Where(x => x.Id == Id).FirstOrDefault();
                //return db.Articulos.Find(sId);
            }
        }

        public static Client Put(Client Item)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    var result = db.Clients.FirstOrDefault(x => x.Id == Item.Id);

                    if (result != null)
                    {
                        result.NumDoc = Item.NumDoc;
                        result.FirstName = Item.FirstName;
                        result.LastName = Item.LastName;
                        result.NumPhone = Item.NumPhone;
                        result.IdTypeDoc = Item.IdTypeDoc;

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

        public static void Post(Client Item)
        {
            // validar campos
            string erroresValidacion = "";
            if (string.IsNullOrEmpty(Item.FirstName))
                erroresValidacion += "Nombre es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.LastName))
                erroresValidacion += "Apellido es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.NumPhone))
                erroresValidacion += "Numero de telefono es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.NumDoc))
                erroresValidacion += "Numero de documento es un dato requerido; ";
            if (!string.IsNullOrEmpty(erroresValidacion))
                throw new ApplicationException(erroresValidacion);

            // grabar registro
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    if (Item.Id != 0)
                    {
                        db.Entry(Item).State = EntityState.Modified;  //vincula entidad y la marca como modificada
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Clients.Add(Item);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // loguearlo y devolver msj generico…
                    throw new ApplicationException("En estos momentos no podemos procesar su solicitud, intente nuevamente más tarde (ref xxxx)");
                }
            }
        }

        public static Client Delete(int id)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                // baja fisica.
                Client client = db.Clients.Find(id);
                if (client == null)
                {
                    return null;
                }
                db.Clients.Remove(client);
                db.SaveChanges();
                return client;
            }
        }
    }
}
