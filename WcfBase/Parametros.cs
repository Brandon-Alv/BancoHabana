using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfBase
{
    [DataContract]
    public class Parametros
    {
        [DataMember]
        public string Monto { get; set; }

        [DataMember]
        public string Fecha { get; set; }

    }
}