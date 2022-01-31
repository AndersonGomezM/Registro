using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entidades
{
    public class RegistroG
    {
        [Key]
        public int RolId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }

        public RegistroG()
        {
            Fecha = DateTime.Now;
        }

        public RegistroG(int rolId, string? descripcion)
        {
            RolId = rolId;
            Fecha = DateTime.Now;
            Descripcion = descripcion;
        }
    }
}