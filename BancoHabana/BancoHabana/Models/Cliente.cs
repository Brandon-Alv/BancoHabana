using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoHabana.Models
{
    public class Cliente
    {

        public Cliente()
        {

        }

        int idcliente;
        String Cedula;
        String nombrecompleto;
        String contraseña;

        //gets
        public String getCedula()
        {
            return Cedula;
        }

        public String getNombrecompleto()
        {
            return nombrecompleto;
        }

        public String getContraseña()
        {
            return contraseña;
        }

        //sets
        public void setCedula(String cedula)
        {
            this.Cedula = cedula;
        }

        public void setNombrecompleto(String nombre)
        {
            this.nombrecompleto = nombre;
        }

        public void setContraseña(String contraseña)
        {
            this.contraseña = contraseña;
        }
    }
}