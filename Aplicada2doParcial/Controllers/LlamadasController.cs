using Aplicada2doParcial.Data;
using Aplicada2doParcial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aplicada2doParcial.Controllers
{
    public class LlamadasController
    {

        public static bool Guardar(Llamadas entity)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if(!db.Llamadas.Any(A=> A.LlamadaId == entity.LlamadaId) && entity.LlamadaId == 0)
                {
                    paso = Insertar(entity);
                }
                else
                {
                    if(db.Llamadas.Any(A=> A.LlamadaId == entity.LlamadaId))
                        paso = Modificar(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Insertar(Llamadas entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Llamadas.Add(entity);
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Llamadas entity)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                var anterior = Buscar(entity.LlamadaId);

                foreach(var obj in entity.Casos)
                {
                    if(obj.CasoId == 0)
                    {
                        db.Entry(obj).State = EntityState.Added;
                    }
                }

                foreach(var obj in anterior.Casos)
                {
                    if(!entity.Casos.Any(A=> A.CasoId == obj.CasoId))
                    {
                        db.Entry(obj).State = EntityState.Deleted;
                    }
                }


                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                Llamadas llamada = Buscar(Id);
                if (llamada != null)
                {
                    db.Entry(llamada).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamadas Buscar(int Id)
        {
            Contexto db = new Contexto();
            Llamadas llamada = null;
            try
            {
                llamada = db.Llamadas.Where(A => A.LlamadaId == Id).Include(A => A.Casos).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamada;
        }


        public static List<Llamadas> GetList(Expression<Func<Llamadas,bool>> expresion)
        {
            List<Llamadas> lista = new List<Llamadas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Llamadas.Where(expresion).Include(A=> A.Casos).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

       
    }
}
