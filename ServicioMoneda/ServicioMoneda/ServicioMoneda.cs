using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMoneda
{
    public class ServicioMoneda : IServicioMoneda
    {
        int IServicioMoneda.getPeso(int cantidadDolar)
        {
            int cantidadNueva = cantidadDolar * 18;
            return cantidadNueva;
        }
        int IServicioMoneda.getDolar(int cantidadPeso)
        {
            int cantidadNueva = cantidadPeso / 18;
            return cantidadNueva;
        }
    }
}
