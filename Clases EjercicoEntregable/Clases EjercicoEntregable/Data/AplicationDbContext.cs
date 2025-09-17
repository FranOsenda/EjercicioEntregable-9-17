using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_EjercicoEntregable.Models;


namespace Clases_EjercicoEntregable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Departamento> departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=Entregable;Trusted_Connection=True;TrustServerCertificate=True;");

        }
    }
}
