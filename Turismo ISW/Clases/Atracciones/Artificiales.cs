using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Atracciones
{
    public enum TipoArtificial
    {
        ParqueDeDiversiones,
        ParqueTematico,
        Shopping
    }

    public abstract class Artificiales : ICombo
    {
        public int Costo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public TipoArtificial Tipo { get; protected set; }

        protected Artificiales(string nombre, string direccion, int costo, TipoArtificial tipo)
        {
            Nombre = nombre;
            Direccion = direccion;
            Costo = costo;
            Tipo = tipo;
        }
    }

    public class ParqueDeDiversiones : Artificiales
    {
        public int CantidadJuegos { get; set; }

        public ParqueDeDiversiones(string nombre, string direccion, int costo, int cantidadJuegos)
            : base(nombre, direccion, costo, TipoArtificial.ParqueDeDiversiones)
        {
            CantidadJuegos = cantidadJuegos;
        }
    }

    public class ParqueTematico : Artificiales
    {
        public bool EsParaMenores { get; set; }

        public ParqueTematico(string nombre, string direccion, int costo, bool esParaMenores)
            : base(nombre, direccion, costo, TipoArtificial.ParqueTematico)
        {
            EsParaMenores = esParaMenores;
        }
    }

    public class Shopping : Artificiales
    {
        public int CantidadTiendas { get; set; }

        public Shopping(string nombre, string direccion, int costo, int cantidadTiendas)
            : base(nombre, direccion, costo, TipoArtificial.Shopping)
        {
            CantidadTiendas = cantidadTiendas;
        }
    }
}