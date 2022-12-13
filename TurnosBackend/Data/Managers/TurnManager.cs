using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class TurnManager
    {
        public static List<Turn> Find(DateTime? Date)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                IQueryable<Turn> consult = db.Turns;
                if (Date.HasValue)
                    consult = consult.Where(x => x.Date == Date);

                var List = consult.OrderBy(x => x.Date).ToList();
                return List;
            }
        }

        public static Turn FindById(int Id)
        {
            using (BdTurnosContext db = new BdTurnosContext()) //el using asegura el db.dispose() que libera la conexion de la base
            {
                return db.Turns.Where(x => x.Id == Id).FirstOrDefault();
                //return db.Articulos.Find(sId);
            }
        }

        public static Turn Put(Turn Item)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    var result = db.Turns.FirstOrDefault(x => x.Id == Item.Id);

                    if (result != null)
                    {
                        result.StartTime = Item.StartTime;
                        result.EndTime = Item.EndTime;
                        result.Date = Item.Date;

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

        public static void Post(Turn Item)
        {
            // validar campos
            string erroresValidacion = "";
            if (Item.StartTime == null)
                erroresValidacion += "Hora de Inicio es un dato requerido; ";
            if (Item.EndTime == null)
                erroresValidacion += "Hora de Fin es un dato requerido; ";
            if (Item.Date == null)
                erroresValidacion += "Fecha es un dato requerido; ";
            //if (Item.Id_Client == null || Item.Id_Client == 0)
            //    erroresValidacion += "Cliente es un dato requerido; ";
            //if (Item.Id_Service == null || Item.Id_Service == 0)
            //    erroresValidacion += "Servicio es un dato requerido; ";
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
                        db.Turns.Add(Item);
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

        public static Turn Delete(int id)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                // baja fisica.
                Turn turn = db.Turns.Find(id);
                if (turn == null)
                {
                    return null;
                }
                db.Turns.Remove(turn);
                db.SaveChanges();
                return turn;
            }
        }
    }
}
