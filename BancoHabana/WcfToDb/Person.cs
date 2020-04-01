using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfToDb
{
    [DataContract]
   public class Person
    {

        [DataMember]
        public string Cedula { get; set; }

    }

    public class Devolver
    {
        [DataMember]
        public string Cedula { get; set; }

        [DataMember]
        public string Fecha { get; set; }

        [DataMember]
        public string Monto { get; set; }

    }
}
