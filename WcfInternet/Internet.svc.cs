using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace WcfInternet
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string FacturaInternet(string Cedula)
        {

            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                String datos = " ";

                using (con)
                {

                    SqlCommand cmd = new SqlCommand("SaldoInternet", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", Cedula);


                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        datos += reader["Monto"].ToString();
                        datos += ",";
                        datos += reader["Fecha"].ToString();

                    }
                    con.Close();
                }

                return datos;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
