using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDeDatos.Ejercicio6
{
    internal class ModuloFactura
    {
        internal static void Alta()
        {

            List<FacturaEnt> facturas = new List<FacturaEnt>();

            while (true)
            {

                FacturaEnt FacturaNueva = IngresarFactura();
                facturas.Add(FacturaNueva);
                Console.WriteLine("Se ha agregado una nueva factura");
                Console.WriteLine($"Cantidad: {facturas.Count}");

                Console.WriteLine("¿Desea continuar agregando facturas? [S/N]");
                string continuar = null;
                while (continuar != "S" && continuar != "N")
                {
                    continuar = Console.ReadLine();
                }

                if (continuar == "N")
                {   foreach(FacturaEnt f in facturas)
                    {
                        FacturaArchivo.AgregarFactura(f);
                    }
                    break;
                }

            }




            FacturaEnt IngresarFactura()
            {
                FacturaEnt factura = new FacturaEnt();

                while (true)
                {

                    ClienteEnt cliente = new ClienteEnt();
                    List<LineaEnt> lineas = new List<LineaEnt>();

                    //CUIT
                    cliente.CUIT = Ingreso.EnteroLargo("el CUIT", 10000000000, 99999999999);

                    //Razon social
                    cliente.RazonSocial = Ingreso.Cadena("la razon social", 1, 30, soloLetras: true);

                    //Detalle
                    while (true)
                    {
                        LineaEnt linea = new LineaEnt();
                        linea.Cantidad = Ingreso.Entero("la cantidad", 1, 100);
                        linea.Producto = Ingreso.Cadena("el producto", 1, 30, soloLetras: true);
                        linea.PrecioUnitarioNeto = Ingreso.Decimal("el precio unitario neto", 1, 1000);
                        lineas.Add(linea);
                        Console.WriteLine("Se ha agregado una linea");
                        Console.WriteLine($"Cantidad: {lineas.Count}");
                        Console.WriteLine("¿Desea continuar agregando lineas? [S/N]");
                        string continuar = null;
                        while (continuar != "S" && continuar != "N")
                        {
                            continuar = Console.ReadLine();
                        }

                        if (continuar == "N")
                        {
                            break;
                        }
                    }

                    //Cliente
                    factura.Cliente = cliente;

                    //Detalle
                    factura.Detalle = lineas;

                    //IVA
                    factura.IVA = Ingreso.Decimal("el IVA", 0, 100);

                    if(!factura.ValidaFactura(out string  error))
                    {
                        Console.WriteLine(error);
                    }

                    break;
                }

                return factura;
            }

     

        }

        internal static void Baja()
        {
            throw new NotImplementedException();
        }

        internal static void Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
