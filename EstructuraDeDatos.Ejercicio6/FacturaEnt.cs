using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos.Ejercicio6
{
    internal class FacturaEnt
    {
        public ClienteEnt Cliente { get; set; }
        public List<LineaEnt> Detalle { get; set; }
        public decimal NetoFactura
        {
            get
            {
                decimal totalFactura = 0;
                foreach (LineaEnt linea in Detalle)
                {
                    totalFactura = totalFactura + linea.Total;
                }
                return totalFactura;
            }
        }
        public decimal IVA { get; set; }
        public decimal TotalIVA 
        {
            get { return (IVA / 100) * NetoFactura; }
        }

        public decimal TotalGeneral
        {
            get { return TotalIVA + NetoFactura; }
        }

        public bool ValidaFactura(out string error)
        {
            error = null;
            if(Detalle.Count == 0)
            {
                error = "Detalle vacio.";
                return false;
            }
            if(Cliente == null)
            {
                error = error + "\n" + "Sin cliente";
                return false;
            }

            return true;

        }
    }
}
