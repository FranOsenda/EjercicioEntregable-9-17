using Clases_EjercicoEntregable.Data;
using Clases_EjercicoEntregable.Models;
using Clases_EjercicoEntregable.Repository;
using Microsoft.Identity.Client;

namespace Front
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = EmpleadoRepository.verEmpleados();
            List<Departamento> departamentos = DepartamentoRepository.verDepartamentos();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1 - Registrar nuevo empleado");
                Console.WriteLine("2 - Actualizar salario de empleado");
                Console.WriteLine("3 - Eliminar empleado");
                Console.WriteLine("4 - Mostar todos los libros y estadisticas generales");
                Console.WriteLine("5 - Salir");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion.Trim())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Email: ");
                        var email = Console.ReadLine();
                        if (empleados.Exists(e => e.email == email))
                        {
                            Console.WriteLine("Ya existe un empleado con ese email.");
                            break;
                        }
                        Console.Write("Salario: ");
                        var salario = decimal.Parse(Console.ReadLine());
                        Console.Write("Departamento Id: ");
                        var deptId = int.Parse(Console.ReadLine());
                        // empRepo.Add(new Empleado { Nombre = nombre, Email = email, Salario = salario, DepartamentoId = deptId });
                        Console.WriteLine("Empleado registrado.");
                        break;


                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;


                    case "3":
                        Console.Clear();

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;

                        // case "5":
                        Console.Clear();
                        
                }
            }

        }
    }
}
