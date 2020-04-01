using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoHabana.Models
{
    public class Movimientos
    {
        public Movimientos()
        {

        }

        public int idmovimiento;
        public int idcuenta;
        public int idcliente;
        public int idtargeta;
        public String saldo;
        public String monto;
        public String descripcion;
        public String fechamovimiento;
        public String Numtarjeta;

        //gets
        public String getSaldo()
        {
            return saldo;
        }

        public String getMonto()
        {
            return monto;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public String getFechamovimiento()
        {
            return fechamovimiento;
        }

        public String getNumtarjeta()
        {
            return Numtarjeta;
        }

        //sets
        public void setSaldo(String saldo)
        {
            this.saldo = saldo;
        }

        public void setMonto(String monto)
        {
            this.monto = monto;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public void setFechamovimiento(String fechamovimiento)
        {
            this.fechamovimiento = fechamovimiento;
        }

        public void setNumtarjeta(String numtarjeta)
        {
            this.Numtarjeta = numtarjeta;
        }
    }
}