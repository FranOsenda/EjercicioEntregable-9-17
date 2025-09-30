using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Transporte
{
    public enum TipoTransportePublico
    {
        Barco,
        Avion,
        Tren
    }

    public abstract class TransportePublico : ICombo
    {

        public int Costo { get; set; }
        public string Marca { get; set; }
        public TipoTransportePublico Tipo { get; protected set; }

        protected TransportePublico(int costo, string marca, TipoTransportePublico tipo)
        {
            Costo = costo;
            Marca = marca;
            Tipo = tipo;
        }
    }

    public class Barco : TransportePublico
    {
        public Barco(int costo, string marca)
            : base(costo, marca, TipoTransportePublico.Barco) { }
    }

    public class Avion : TransportePublico
    {
        public Avion(int costo, string marca)
            : base(costo, marca, TipoTransportePublico.Avion) { }
    }

    public class Tren : TransportePublico
    {
        public Tren(int costo, string marca)
            : base(costo, marca, TipoTransportePublico.Tren) { }
    }
}
