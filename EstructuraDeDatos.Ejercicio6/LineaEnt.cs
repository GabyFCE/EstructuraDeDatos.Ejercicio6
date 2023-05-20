using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos.Ejercicio6
{
    internal class LineaEnt
    {
        public int Cantidad { get; set; }
        public string Producto { get; set;}
        public decimal PrecioUnitarioNeto { get; set; }
        public decimal Total
        {
            get
            { return Cantidad * PrecioUnitarioNeto; }
        }
    }
}
