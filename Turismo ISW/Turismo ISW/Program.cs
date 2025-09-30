namespace Turismo_ISW
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
/* El combo tiene viajes, reservas de hotel y visitas a atracciones. Deben tener en cuenta que los viajes pueden ser en transporte publico
 * o en transporte privado, en los privados por ejemplo esta, el uber, el remis y el taxi. En los viajes en transporte publico
 * puede ser en barco, tren y avion. 
En las reservas de hotel, pueden ser hoteles 3, 4 y 5 estrellas. y una marca que indica o no si tiene helipuerto. O tambien pueden ser en cabañas
las cabañas indican la cantidad de personas que pueden ser alojadas. (capacidad)
Para las atracciones, hay dos categorias, las artificiales y las naturales. Dentro de las artificiales tenemos los parques tematicos, parque
de diversiones y shopings 
Debemos tener en cuenta que los parques tematicos hay que registrar si son para menores de edad o para adultos. 
En los naturales tenemos 3 grupos: agua y las montañas y selva. En montaña podemos escalar y hacer trekking. 
Agua cataratas del iguazu, playas y lagos. 
Si son de selva, hay dos grandes categorias  Selva de clima lluvioso o selva de vegetacion media. 
En las de clima lluvioso tenemos, el amazonas y la selva misionera. En la de vegetacion media tenemos la selva del norte de africa y sur de china.

Todas estas atracciones tienen un costo de entrada.
Minimo las propiedades que deben tener son: nombre y costo. Ademas, las de transporte publico tienen la marca del transporte.

Solo un boton y que el cliente haya comprado uno de cada uno y mostrar el precio total del combo. 
 */