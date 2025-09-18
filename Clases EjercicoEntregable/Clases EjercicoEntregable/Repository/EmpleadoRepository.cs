using Clases_EjercicoEntregable.Data;
using Clases_EjercicoEntregable.Models;
using Clases_EjercicoEntregable.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_EjercicoEntregable.Repository
{
    public static class EmpleadoRepository
    {
        public static void GuardarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();
            context.empleados.Add(empleado);
            context.SaveChanges();
        }
        public static List<Empleado> verEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.empleados.ToList();
        }
        public static void guardarCambios()
        {
            using var context = new ApplicationDbContext();
            context.SaveChanges();
        }
    }
}
