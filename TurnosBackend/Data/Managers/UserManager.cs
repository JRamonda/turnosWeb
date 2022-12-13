using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class UserManager
    {
        public async static Task<IEnumerable<object>> Find(int? IdProfile)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                var consult = db.Users.Select(c => new
                {
                    c.Id,
                    c.Username,
                    c.Password,
                    c.Email,
                    c.FirstName,
                    c.LastName,
                    c.IdProfile,
                    Profile = c.Profile
                });

                if (IdProfile != null)
                    consult = consult.Where(x => x.IdProfile == IdProfile);

                return consult.OrderBy(x => x.FirstName).ToList();       
            }
        }

        public async static Task<object> FindById(int Id)
        {
            using (BdTurnosContext db = new BdTurnosContext()) //el using asegura el db.dispose() que libera la conexion de la base
            {
                return db.Users
                    .Select(c => new
                    {
                        c.Id,
                        c.Username,
                        c.Password,
                        c.Email,
                        c.FirstName,
                        c.LastName,
                        c.IdProfile,
                        Profile = c.Profile
                    }).Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public static User Put(User Item)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    var result = db.Users.FirstOrDefault(x => x.Id == Item.Id);

                    if (result != null)
                    {
                        result.Password = Item.Password;
                        result.FirstName = Item.FirstName;
                        result.LastName = Item.LastName;
                        result.Email = Item.Email;
                        result.IdProfile = Item.IdProfile;

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

        public static void Post(User Item)
        {
            // validar campos
            string erroresValidacion = "";
            if (string.IsNullOrEmpty(Item.Username))
                erroresValidacion += "Nombre de usuario es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.Password))
                erroresValidacion += "Contraseña es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.Email))
                erroresValidacion += "Email es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.FirstName))
                erroresValidacion += "Nombre es un dato requerido; ";
            if (string.IsNullOrEmpty(Item.LastName))
                erroresValidacion += "Apellido es un dato requerido; ";
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
                        db.Users.Add(Item);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("En estos momentos no podemos procesar su solicitud, intente nuevamente más tarde (ref xxxx)");
                }
            }
        }

        public static User Delete(int id)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                // baja fisica.
                User User = db.Users.Find(id);
                if (User == null)
                {
                    return null;
                }
                db.Users.Remove(User);
                db.SaveChanges();
                return User;
            }
        }
    }
}
