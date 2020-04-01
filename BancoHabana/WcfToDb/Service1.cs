using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfToDb
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        public Service1() 
        {
            Conexion c = new Conexion();
            c.ObtenerConexion();
        }
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

        public void InsertDatos(Person p)
        {

            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("Ingresar", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cedula", p.Cedula);

                    cmd.ExecuteScalar();
                    
                    con.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        public Devolver GetDevolver(Devolver d)
        {
            Devolver dev = new Devolver();

            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("Mostrar", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cedula", d.Cedula);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dev.Fecha = reader["Fecha"].ToString();
                        dev.Monto = reader["Monto"].ToString();
                    }

                    return dev;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
