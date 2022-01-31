using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using BLL;
using Entidades;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<RegistroG>? RegistroG { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Registro.db");
        }
    }
}