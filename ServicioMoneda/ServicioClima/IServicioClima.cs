using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMoneda.ServicioClima
{
    [ServiceContract]
    internal interface IServicioClima
    {
        [OperationContract]
        int getC(int cantidadF);

        [OperationContract]
        int getF(int cantidadC);
    }
}
