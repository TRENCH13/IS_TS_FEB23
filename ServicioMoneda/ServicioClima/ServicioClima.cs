using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMoneda.ServicioClima
{
    internal class ServicioClima : IServicioClima
    {
        int IServicioClima.getC(int cantidadF)
        {
            int cantidadNueva = cantidadF / 33;
            return cantidadNueva;
        }

        int IServicioClima.getF(int cantidadC)
        {
            int cantidadNueva = cantidadC * 33;
            return cantidadNueva;
        }
    }
}
