using Clases_EjercicoEntregable.Data;
using Clases_EjercicoEntregable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_EjercicoEntregable.Repository;
using Clases_EjercicoEntregable.Models;
namespace Clases_EjercicoEntregable.Repository

{
    public static class DepartamentoRepository
    {
        public static void GuardarDepartamento(Departamento departamento)
        {
            using var context = new ApplicationDbContext();
            context.departamentos.Add(departamento);
            context.SaveChanges();
        }
        public static List<Departamento> verDepartamentos()
        {
            using var context = new ApplicationDbContext();
            return context.departamentos.ToList();
        }
        public static void guardarCambios()
        {
            using var context = new ApplicationDbContext();
            context.SaveChanges();
        }

    }
}
