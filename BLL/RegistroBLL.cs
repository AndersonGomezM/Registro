using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL;

namespace BLL
{
    public class RegistroBLL
    {
        public static bool Insertar(RegistroG registro)
        {
            bool confirmar = false;

            using (var contexto = new Contexto())
            {
                contexto.RegistroG?.Add(registro);
                confirmar = contexto.SaveChanges() > 0;
            }

            return confirmar;
        }

        public static List<RegistroG> GetLista()
        {
            using (Contexto contexto = new Contexto())
            {
                return contexto.RegistroG.ToList ();
            }
        }

        public static bool Eliminar(RegistroG registro)
        {
            bool confirmar = false;

            return confirmar;
        }

        public static bool Editar(RegistroG registro)
        {
            bool confirmar = false;

            return confirmar;
        }
    }
}