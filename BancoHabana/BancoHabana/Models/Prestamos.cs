using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoHabana.Models
{
    public class Prestamos
    {
        public Prestamos()
        {

        }

       public int idprestamo;
        public int idcliente;
        public int idcuenta;
        public String numprestamo;
        public String informacion;
        public String cuota;
        public String saldo;
        public String fechapago;
        public String opcionpago;
        public String Numcuenta;

        //gets
        public String getNumprestamo()
        {
            return numprestamo;
        }

        public String getInformacion()
        {
            return informacion;
        }

        public String getCuota()
        {
            return cuota;
        }

        public String getSaldo()
        {
            return saldo;
        }

        public String getFechapago()
        {
            return fechapago;
        }

        public String getOpcionpago()
        {
            return opcionpago;
        }

        public String getNumcuenta()
        {
            return Numcuenta;
        }

        //sets
        public void setNumprestamo(String numprestamo)
        {
            this.numprestamo = numprestamo;
        }

        public void setInformacion(String informacion)
        {
            this.informacion = informacion;
        }

        public void setCuota(String cuota)
        {
            this.cuota = cuota;
        }

        public void setSaldo(String saldo)
        {
            this.saldo = saldo;
        }

        public void setFechapago(String fechapago)
        {
            this.fechapago = fechapago;
        }

        public void setOpcionpago(String opcionpago)
        {
            this.opcionpago = opcionpago;
        }

        public void setNumcuenta(String numcuenta)
        {
            this.Numcuenta = numcuenta;
        }
    }
}