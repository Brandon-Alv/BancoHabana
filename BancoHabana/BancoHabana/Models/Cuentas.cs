using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoHabana.Models
{
    public class Cuentas
    {
        public Cuentas()
        {

        }

        int idcuenta;
        int idcliente;
        public  String numcuenta;
        public String saldo;
        public String saldobloqueado;
        public String saldocongelado;
        public String titular;

        //gets
        public String getNumcuenta()
        {
            return numcuenta;
        }

        public String getSaldo()
        {
            return saldo;
        }

        public String getSaldobloqueado()
        {
            return saldobloqueado;
        }

        public String getSaldocongelado()
        {
            return saldocongelado;
        }

        public String getTitular()
        {
            return titular;
        }

        //sets
        public void setNumcuenta(String numcuenta)
        {
            this.numcuenta = numcuenta;
        }

        public void setSaldo(String saldo)
        {
            this.saldo = saldo;
        }

        public void setSaldobloqueado(String saldobloqueado)
        {
            this.saldobloqueado = saldobloqueado;
        }

        public void setSaldocongelado(String saldocongelado)
        {
            this.saldocongelado = saldocongelado;
        }

        public void setTitular(String titular)
        {
            this.titular = titular;
        }
    }
}