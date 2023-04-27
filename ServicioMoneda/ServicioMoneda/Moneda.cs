using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ServicioMoneda
{
    [DataContract]
    internal class Moneda
    {
        [DataMember]
        public int cantidadPeso { get; set; }
        [DataMember]
        public int cantidadDolar { get; set; }

    }
}
