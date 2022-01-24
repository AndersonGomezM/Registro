using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace BLL
{
    public class RegistroG
    {
        [Key]
        public string? RolId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }

        public RegistroG()
        {
            Fecha = DateTime.Now;
        }

        public RegistroG(string? rolId, string? descripcion)
        {
            RolId = rolId;
            Fecha = DateTime.Now;
            Descripcion = descripcion;
        }
    }
}