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
                Console.WriteLine("4 - Registrar nuevo departamento");
                Console.WriteLine("5 - Estadísticas de empleados");
                Console.WriteLine("6 - Salir");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion.Trim())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Nombre: ");
                        var nombre = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        if (empleados.Exists(e => e.email == email))
                        {
                            Console.WriteLine("Ya existe un empleado con ese email.");
                            break;
                        }
                        Console.Write("Salario: ");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Los departamentos disponibles son:");
                        foreach (var dept in departamentos)
                        {
                            Console.WriteLine($"Id: {dept.id}, Nombre: {dept.nombre}");
                        }
                        Console.Write("Departamento Id: ");
                        int departamentoID = int.Parse(Console.ReadLine());
                        if (!departamentos.Exists(d => d.id == departamentoID))
                        {
                            Console.WriteLine("No existe un departamento con ese Id.");
                            break;
                        }
                        Empleado empleado = new Empleado() { nombre = nombre, email = email, salario = salario, DepartamentoId = departamentoID };
                        empleados.Add(empleado);
                        EmpleadoRepository.GuardarEmpleado(empleado);
                        Console.WriteLine("Empleado registrado.\n");

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Actualizar salario empleado");
                        Console.Write("Ingrese el email del empleado: ");
                        string emailActualizar = Console.ReadLine();
                        Empleado empleadoActualizar = empleados.FirstOrDefault(e => e.email == emailActualizar);
                        if (empleadoActualizar == null)
                        {
                            Console.WriteLine("Empleado no encontrado.");
                        }
                        else
                        {
                            Console.Write("Nuevo salario: ");
                            empleadoActualizar.salario = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Salario actualizado.");
                        }
                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Ingrese el email del empleado a eliminar: ");
                        string emailEliminar = Console.ReadLine();
                        Empleado empleadoEliminar = empleados.FirstOrDefault(e => e.email == emailEliminar);
                        if (empleadoEliminar == null)
                        {
                            Console.WriteLine("Empleado no encontrado.");
                        }
                        else
                        {
                            empleados.Remove(empleadoEliminar);
                            Console.WriteLine("Empleado eliminado.");
                        }
                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Registrar nuevo departamento");
                        Console.Write("Nombre del departamento: ");
                        string nombreDept = Console.ReadLine();
                        Console.Write("Descripción del departamento: ");
                        string descripcionDept = Console.ReadLine(); 
                        Departamento departamento = new Departamento() { nombre = nombreDept, descripcion = descripcionDept };
                        departamentos.Add(departamento);
                        DepartamentoRepository.GuardarDepartamento(departamento);

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Estadísticas de empleados");
                        int totalEmpleados = empleados.Count;
                        if (totalEmpleados == 0)
                        {
                            Console.WriteLine("No hay empleados registrados.");
                            break;
                        }
                        else
                        {
                            decimal salarioPromedio = empleados.Average(e => e.salario);
                            Console.WriteLine($"Total de empleados: {totalEmpleados}");
                            Console.WriteLine($"Salario promedio: {salarioPromedio}");
                            Console.WriteLine("Para volver al menu principal presione una tecla");
                            Console.ReadKey();
                            break;
                        }

                }
            }

        }
    }
}
