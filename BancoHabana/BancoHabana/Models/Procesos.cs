using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BancoHabana.Models
{
    public class Procesos
    {
        public String Log = " ";
        public String Login(String Cedula, String Contra)
        {
            
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con) 
                {

                    SqlCommand cmd = new SqlCommand("Usuarios", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", Cedula);
                    cmd.Parameters.AddWithValue("@contra", Contra);

                    SqlDataReader reader = cmd.ExecuteReader();

                    String Contrra="";
                    String Cedu = "";
                    String Correo = "";
                    

                    while (reader.Read())
                    {
                        Contrra = reader["Contraseña"].ToString();
                        Cedu = reader["Cedula"].ToString();
                        Correo = reader["correo"].ToString();
                    }
                    con.Close();

                    if (Cedula.Equals(Cedu) && Contra.Equals(Contrra))
                    {
                        GenerarToken(Correo);
                        Log = "Correcto";
                        
                    }
                    else
                    {
                        Log = "Incorrecto";
                    }

                    return Correo;

                }

               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void newpass(String correo, String contraseña)
        {
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();
            


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("newpass", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);


                    cmd.ExecuteScalar();

                    con.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarToken(String correo) 
        {

            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            Random r = new Random();
            int num = r.Next(0, 9999);



            EnviarCorreo ev = new EnviarCorreo();
            ev.EnviarToken(correo, num);


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("ActualizarToken", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@token", num);

                    cmd.ExecuteScalar();

                    con.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ValidarToken(String Token, String Correo)
        {

           
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("LlamadaToke", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@correo",Correo);



                    SqlDataReader reader = cmd.ExecuteReader();

                    String Tokken = "";

                    while (reader.Read())
                    {
                        Tokken = reader["Token"].ToString();
                    }
                    con.Close();


                    if (Token.Equals(Tokken))
                    {
                        val = "Correcto";
                    }
                    else
                    {
                        val = "Incorrecto";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public String val = " ";

        public List<Cuentas> getCuentas(String Cedula)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("CuentasAsociadas", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", Cedula);
                    

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cuentas> cuen = new List<Cuentas>();


                    while (reader.Read())
                    {

                        Cuentas ce = new Cuentas();

                        ce.setNumcuenta(reader["NumCuenta"].ToString());
                        cuen.Add(ce);
                    }
                    con.Close();

                    return cuen;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<Tarjetas> getTarjetas(String Cedula)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("TarCuentaI", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", Cedula);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tarjetas> tar = new List<Tarjetas>();


                    while (reader.Read())
                    {

                        Tarjetas t = new Tarjetas();
                        t.setNumtargeta(reader["NumTarjeta"].ToString());

                        tar.Add(t);
                    }
                    con.Close();

                    return tar;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Prestamos getPrestamos(String targeta)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("PrestamosEnla", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numprestamo", targeta);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Prestamos> tar = new List<Prestamos>();

                    Prestamos pr = new Prestamos();
                    while (reader.Read())
                    {

                        

                        pr.setNumcuenta(reader["NumCuenta"].ToString());
                        pr.setSaldo(reader["Saldo"].ToString());
                        pr.setInformacion(reader["informacion"].ToString());
                        pr.setCuota(reader["Cuota"].ToString());
                        pr.setFechapago(reader["FechaPago"].ToString());
                        pr.setOpcionpago(reader["OpcionPago"].ToString());

                        tar.Add(pr);
                    }
                    con.Close();

                    return pr;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Tarjetas getDatosTarjetas(String targeta)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("OpcionesTar", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumTar", targeta);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tarjetas> tar = new List<Tarjetas>();

                    Tarjetas pr = new Tarjetas();
                    while (reader.Read())
                    {

                        pr.setDeuda(reader["Deuda"].ToString());
                        pr.setFechapago(reader["FechaPago"].ToString());
                        pr.setOpcionpago(reader["OpcionPago"].ToString());


                        tar.Add(pr);
                    }
                    con.Close();

                    return pr;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cuentas getDatosCuentas(String cuenta)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("SaldoCuenta", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numcuenta", cuenta);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cuentas> tar = new List<Cuentas>();

                    Cuentas pr = new Cuentas();

                    while (reader.Read())
                    {

                        pr.setSaldo(reader["Saldo"].ToString());
                        pr.setTitular(reader["NombreCompleto"].ToString());
                        


                        tar.Add(pr);
                    }
                    con.Close();

                    return pr;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Movimientos> getDatosMovimientos(String cuenta)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("MovimientosCuenta", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numcuenta", cuenta);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Movimientos> tar = new List<Movimientos>();

                   

                    while (reader.Read())
                    {

                        Movimientos pr = new Movimientos();

                        pr.setNumtarjeta(reader["NumTarjeta"].ToString());
                        pr.setSaldo(reader["Saldo"].ToString());
                        pr.setMonto(reader["Monto"].ToString());
                        pr.setDescripcion(reader["Descripcion"].ToString());
                        pr.setFechamovimiento(reader["FechaMovimiento"].ToString());
                        




                        tar.Add(pr);
                    }
                    con.Close();

                    return tar;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Cuentas getDatosEstados(String cuenta)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("SaldoCuenta1", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numcuenta", cuenta);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cuentas> tar = new List<Cuentas>();

                    Cuentas pr = new Cuentas();

                    while (reader.Read())
                    {

                       

                        pr.setSaldo(reader["Saldo"].ToString());
                        pr.setSaldobloqueado(reader["SaldoBloqueado"].ToString());
                        pr.setSaldocongelado(reader["SaldoCongelado"].ToString());
                        pr.setTitular(reader["NombreCompleto"].ToString());
                        





                        tar.Add(pr);
                    }
                    con.Close();

                    return pr;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Tarjetas> getTodasTarjetas(String cedula)
        {
            EnviarCorreo e = new EnviarCorreo();
            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();


            try
            {
                using (con)
                {

                    SqlCommand cmd = new SqlCommand("targetasCliente", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", cedula);


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Tarjetas> tar = new List<Tarjetas>();

                    

                    String num;

                    while (reader.Read())
                    {
                      Tarjetas pr = new Tarjetas();


                        pr.setNumtargeta(reader["NumTarjeta"].ToString());

                        

                        tar.Add(pr);

                        num = pr.getNumtargeta();

                    }
                    con.Close();

                    return tar;

                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AumentarCuenta(String monto,String cuenta)
        {




            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("sumartarjeta", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tarjeta", cuenta);
                    cmd.Parameters.AddWithValue("@monto",   Convert.ToInt32(monto));
                    
                    


                    cmd.ExecuteScalar();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void AgregarMovimiento(String monto, String cuenta)
        {




            Conexion c = new Conexion();
            SqlConnection con = new SqlConnection();
            con = c.ObtenerConexion();

            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("agregarmovimientos", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tarjeta", cuenta);
                    cmd.Parameters.AddWithValue("@monto", Convert.ToInt32(monto));




                    cmd.ExecuteScalar();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }






    }
}