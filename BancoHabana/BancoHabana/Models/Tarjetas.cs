using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoHabana.Models
{
    public class Tarjetas
    {
        public Tarjetas()
        {

        }

       public int idtargeta;
        public int idcuenta;
        public int idcliente;
        public String numtargeta;
        public String deuda;
        public String fechapago;
        public String opcionpago;

        //gets
        public String getNumtargeta()
        {
            return numtargeta;
        }

        public String getDeuda()
        {
            return deuda;
        }

        public String getFechapago()
        {
            return fechapago;
        }

        public String getOpcionpago()
        {
            return opcionpago;
        }

        //sets
        public void setNumtargeta(String numtargeta)
        {
            this.numtargeta = numtargeta;
        }

        public void setDeuda(String deuda)
        {
            this.deuda = deuda;
        }

        public void setFechapago(String fechapago)
        {
            this.fechapago = fechapago;
        }

        public void setOpcionpago(String opcionpago)
        {
            this.opcionpago = opcionpago;
        }
    }
}