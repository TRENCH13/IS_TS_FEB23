using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicioMoneda
{
    [ServiceContract]
    public interface IServicioMoneda
    {
        [OperationContract]
        int getPeso(int cantidadDolar);

        [OperationContract]
        int getDolar(int cantidadPeso);

    }
}
