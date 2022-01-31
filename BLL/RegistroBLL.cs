using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using DAL;
using Entidades;

namespace BLL
{
    public class RegistroBLL
    {
        public static bool Insertar(RegistroG registro)
        {
            bool confirmar = false;

            using (var contexto = new Contexto())
            {
                contexto.RegistroG.Add(registro);
                confirmar = contexto.SaveChanges() > 0;
            }

            return confirmar;
        }

        public static List<RegistroG> GetLista()
        {
            using (Contexto contexto = new Contexto())
            {
                return contexto.RegistroG.ToList();
            }
        }

        public static bool Eliminar(int id)
        {
            bool confirmar = false;
            Contexto contexto = new Contexto();
            try
            {
                var registro = contexto.RegistroG.Find(id);
                
                if (registro != null)
                {
                    contexto.RegistroG.Remove(registro);
                    confirmar = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return confirmar;
        }

        public static bool Editar(RegistroG registro)
        {
            bool confirmar = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(registro).State = EntityState.Modified;
                confirmar = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return confirmar;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool confirmar = false;

            try
            {
                confirmar = contexto.RegistroG.Any(e => e.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return confirmar;
        }
    }
}