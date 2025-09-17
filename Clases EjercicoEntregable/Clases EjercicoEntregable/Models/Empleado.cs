using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Clases_EjercicoEntregable.Models;
using Clases_EjercicoEntregable.Repository;
namespace Clases_EjercicoEntregable.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public decimal salario { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

    }
    
}
