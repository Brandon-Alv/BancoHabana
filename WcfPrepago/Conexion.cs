using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WcfPrepago
{
    public class Conexion
    {

        public SqlConnection con = new SqlConnection();

        public SqlConnection ObtenerConexion()
        {
            con = new SqlConnection("Password=progra;Persist Security Info=True;User ID=sa;Initial Catalog=ServicioTelefono;Data Source=DESKTOP-OTPQGFQ");

            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool DescargarConexion()
        {
            con.Dispose();
            return true;
        }

    }
}