using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WcfToDb
{
    class Conexion
    {

        public SqlConnection con = new SqlConnection();


        public SqlConnection ObtenerConexion()
        {
            con = new SqlConnection("Password=carlos;Persist Security Info=True;User ID=sa;Initial Catalog=ServiciosAgua; Data Source=DESKTOP-OTPQGFQ");

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

