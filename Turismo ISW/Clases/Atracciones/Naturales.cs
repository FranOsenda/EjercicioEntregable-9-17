using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public enum TipoNatural
{
    Montaña,
    Agua,
    Selva
}

public abstract class Natural : ICombo
{
    public string Nombre { get; set; }
    public int Costo { get; set; }
    public TipoNatural Tipo { get; protected set; }

    protected Natural(string nombre, int costo, TipoNatural tipo)
    {
        Nombre = nombre;
        Costo = costo;
        Tipo = tipo;
    }
}
public class Montaña : Natural
{
    public bool SePuedeEscalar { get; set; }
    public bool SePuedeTrekking { get; set; }

    public Montaña(string nombre, int costo, bool escalar, bool trekking)
        : base(nombre, costo, TipoNatural.Montaña)
    {
        SePuedeEscalar = escalar;
        SePuedeTrekking = trekking;
    }
}

public class Agua : Natural
{
    public string TipoAgua { get; set; }

    public Agua(string nombre, int costo, string tipoAgua)
        : base(nombre, costo, TipoNatural.Agua)
    {
        TipoAgua = tipoAgua;
    }
}

public class Selva : Natural
{
    public string TipoClima { get; set; } 
    public string Region { get; set; }    

    public Selva(string nombre, int costo, string tipoClima, string region)
        : base(nombre, costo, TipoNatural.Selva)
    {
        TipoClima = tipoClima;
        Region = region;
    }
}


