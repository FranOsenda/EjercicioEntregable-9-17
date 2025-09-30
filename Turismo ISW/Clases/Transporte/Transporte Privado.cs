using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Transporte
{
    public enum TipoTransporte
    {
        Taxi,
        Uber,
        Remis
    }

    public abstract class TransportePrivado : ICombo
    {
        public int Costo { get; set; }
        public string Capacidad { get; set; }
        public string Horario { get; set; }
        public TipoTransporte Tipo { get; protected set; }

        protected TransportePrivado(int costo, string capacidad, string horario, TipoTransporte tipo)
        {
            Costo = costo;
            Capacidad = capacidad;
            Horario = horario;
            Tipo = tipo;
        }
    }

    public class Taxi : TransportePrivado
    {
        public string NumeroLicencia { get; set; }
        public string Color { get; set; }

        public Taxi(int costo, string capacidad, string horario, string numeroLicencia, string color)
            : base(costo, capacidad, horario, TipoTransporte.Taxi)
        {
            NumeroLicencia = numeroLicencia;
            Color = color;
        }
    }

    public class Uber : TransportePrivado
    {
        public string Aplicacion { get; set; }
        public double Calificacion { get; set; }
        public string Chofer { get; set; }

        public Uber(int costo, string capacidad, string chofer, string horario, string aplicacion, double calificacion)
            : base(costo, capacidad, horario, TipoTransporte.Uber)
        {

            Chofer = chofer; 
            Aplicacion = aplicacion;
            Calificacion = calificacion;
        }
    }

    public class Remis : TransportePrivado
    {
        public string Empresa { get; set; }
        public bool Servicio24Horas { get; set; }

        public Remis(int costo, string capacidad, string horario, string empresa, bool servicio24Horas)
            : base(costo, capacidad, horario, TipoTransporte.Remis)
        {
            Empresa = empresa;
            Servicio24Horas = servicio24Horas;
        }
    }
}