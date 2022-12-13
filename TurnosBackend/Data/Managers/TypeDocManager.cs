using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Managers
{
    public class TypeDocManager
    {
        public static List<TypeDoc> Find(string? Name)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                IQueryable<TypeDoc> consult = db.TypeDocs;

                if (!string.IsNullOrEmpty(Name))
                    consult = consult.Where(x => x.Name.Contains(Name));

                var List = consult.OrderBy(x => x.Id).ToList();
                return List;
            }
        }

        public static TypeDoc FindById(int Id)
        {
            using (BdTurnosContext db = new BdTurnosContext()) //el using asegura el db.dispose() que libera la conexion de la base
            {
                return db.TypeDocs.Where(x => x.Id == Id).FirstOrDefault();
                //return db.Articulos.Find(sId);
            }
        }

        public static void Post(TypeDoc Item)
        {
            // validar campos
            string erroresValidacion = "";
            if (string.IsNullOrEmpty(Item.Name))
                erroresValidacion += "Nombre es un dato requerido; ";
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
                        db.TypeDocs.Add(Item);
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

        public static TypeDoc Put(TypeDoc Item)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                try
                {
                    var result = db.TypeDocs.FirstOrDefault(x => x.Id == Item.Id);

                    if (result != null)
                    {
                        result.Name = Item.Name;

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

        public static TypeDoc Delete(int id)
        {
            using (BdTurnosContext db = new BdTurnosContext())
            {
                // baja fisica.
                TypeDoc typeDoc = db.TypeDocs.Find(id);
                if (typeDoc == null)
                {
                    return null;
                }
                db.TypeDocs.Remove(typeDoc);
                db.SaveChanges();
                return typeDoc;
            }
        }
    }
}
