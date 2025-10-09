using Clases_EjercicoEntregable.Data;
using Clases_EjercicoEntregable.Models;
using Clases_EjercicoEntregable.Repository;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq; 

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
                Console.WriteLine("7 - Consultas LINQ (Otro Ejercicio");
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
                        Empleado empleado = new Empleado()
                        {
                            nombre = nombre, 
                            email = email, 
                            salario = salario, 
                            DepartamentoId = departamentoID 
                        };
                        empleados.Add(empleado);

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
                            EmpleadoRepository.guardarCambios();
                            Console.WriteLine("Empleado eliminado.");
                        }
                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Registrar nuevo departamento");
                        Console.Write("Nombre del departamento: ");
                        string nombreDepartamento = Console.ReadLine();
                        Console.Write("Descripción del departamento: ");
                        string descripcionDepartamento = Console.ReadLine(); 
                        Departamento departamento = new Departamento()
                        {
                            nombre = nombreDepartamento, 
                            descripcion = descripcionDepartamento 
                        };
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
                    case "6":
                        Console.WriteLine("Saliendo del programa...");
                        return; 
                    case "7": 
                        Console.Clear();
                        Console.WriteLine("Consultas LINQ\n");

                        Console.WriteLine("1 - Consultas Basicas");
                        Console.WriteLine("2 - Estadisticas ");
                        Console.WriteLine("3 - Filtros y Condiciones");
                        Console.WriteLine("4 - Consultas Combinadas");
                        string opcionLINQ = Console.ReadLine();
                        switch (opcionLINQ.Trim())
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("----- CONSULTAS BASICAS -----\n");
                                Console.WriteLine("Seleccione una opcion \n ");
                                Console.WriteLine("1 - Obtener todos los empleados ordenados alfabéticamente por nombre.");
                                Console.WriteLine("2 - Mostrar solo los nombres y emails de los empleados.");
                                Console.WriteLine("3 - Buscar el empleado con el salario más alto.");
                                Console.WriteLine("4 - Listar los empleados cuyo salario sea mayor a 100000.");
                                Console.WriteLine("5 - Mostrar los nombres de los empleados que pertenecen al departamento \"Desarrollo\"");
                                Console.WriteLine("6 - Volver atras\n");
                                Console.WriteLine("Seleccione una opcion:");

                                string opcionBasicas = Console.ReadLine();
                                switch (opcionBasicas.Trim())
                                {
                                    case "1":
                                        IEnumerable<Empleado> empleadosOrdenados = empleados.OrderBy(e => e.nombre).ToList();
                                        foreach (var emp in empleadosOrdenados)
                                        {
                                            Console.WriteLine($"Nombre: {emp.nombre}, Email: {emp.email}, Salario: {emp.salario}, DepartamentoId: {emp.DepartamentoId}");
                                        }
                                        break;
                                    case "2":
                                        var empleadosNombresEmails = from emp in empleados select new Empleado
                                        {
                                            nombre = emp.nombre,
                                            email = emp.email
                                        };
                                        foreach (var emp in empleadosNombresEmails)
                                        {
                                            Console.WriteLine($"Nombre: {emp.nombre}, Email: {emp.email}");
                                        }
                                        break;
                                    case "3":
                                        Empleado empleadoSalarioAlto = empleados.OrderByDescending(e => e.salario).FirstOrDefault();
                                        if (empleadoSalarioAlto != null)
                                        {
                                            Console.WriteLine($"Empleado con salario más alto: {empleadoSalarioAlto.nombre}, Salario: {empleadoSalarioAlto.salario}");
                                        }
                                        break;
                                    case "4":
                                        IEnumerable<Empleado> empleadosSalarioAlto = empleados.Where(e => e.salario > 100000);
                                        foreach (var emp in empleadosSalarioAlto)
                                        {
                                            Console.WriteLine($"Nombre: {emp.nombre}, Salario: {emp.salario}");
                                        }
                                        break;
                                    case "5":
                                        var empleadosDesarrollo = from emp in empleados
                                                                  join dept in departamentos on emp.DepartamentoId equals dept.id
                                                                  where dept.nombre.ToLower() == "desarrollo"
                                                                  select emp;
                                        foreach (var emp in empleadosDesarrollo)
                                        {
                                            Console.WriteLine($"Nombre: {emp.nombre}, Departamento: Desarrollo");
                                        }
                                        break;
                                    case "6":
                                        break;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Estadisticas");
                                Console.WriteLine("1 - Mostrar el nombre del departamento con más empleados.");
                                Console.WriteLine("2 - Volver atras \n");
                                Console.WriteLine("Seleccione una opcion");
                                string opcionEstadisticas = Console.ReadLine();
                                switch (opcionEstadisticas.Trim())
                                {
                                    case "1":
                                        IEnumerable<object> deptMasEmpleados = empleados
                                            .GroupBy(e => e.DepartamentoId)
                                            .Select(g => new { DepartamentoId = g.Key, CantidadEmpleados = g.Count() })
                                            .OrderByDescending(g => g.CantidadEmpleados)
                                            .Take(1)
                                            .Join(departamentos, g => g.DepartamentoId, d => d.id, (g, d) => new { d.nombre, g.CantidadEmpleados });

                                        break;
                                    case "2":
                                        break;
                                }
                                break;
                            case "3":
                                Console.WriteLine("Filtros y Condiciones");

                                Console.WriteLine("1 - Mostrar empleados cuyo email termine en \"@gmail.com\"."); 
                                Console.WriteLine("2 - Listar empleados cuyo nombre empiece con \"A\".");
                                Console.WriteLine("3 - Buscar si existe al menos un empleado con salario menor a 50000.");
                                Console.WriteLine("4 - Obtener los empleados que no tienen departamento asignado(IdDepartamento no existe en la lista de departamentos).");
                                Console.WriteLine("5 - Mostrar empleados que pertenezcan a los departamentos \"Ventas\" o \"Soporte\".");
                                Console.WriteLine("6 - Volver atras \n");
                                Console.WriteLine("Seleccione una opcion");
                                string opcionFiltros = Console.ReadLine();
                                switch (opcionFiltros.Trim())
                                {
                                    case "1":
                                        break; 
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                    case "4":
                                        break; 
                                    case "5":
                                        break;
                                    case "6":
                                        break;
                                


                                }
                                break; 

                        }
                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;


                }
            }

        }
    }
}
