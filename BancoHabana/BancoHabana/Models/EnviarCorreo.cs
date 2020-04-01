using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace BancoHabana.Models
{
    public class EnviarCorreo
    {

        public void EnviarToken(String Correo, int token)
        {
            String Usuario, contraseña, destinatario, asunto, mensaje;

            Usuario = "acmeempresa2019@gmail.com";
            contraseña = "ACME2019";
            destinatario = Correo;
            asunto = "Validacion de Cuenta";
            mensaje = token.ToString();


            MailMessage enviar = new MailMessage(Usuario, destinatario, asunto, mensaje);
            SmtpClient servidor = new SmtpClient("smtp.gmail.com");
            servidor.Port = 587;
            servidor.EnableSsl = true;
            servidor.UseDefaultCredentials = false;

            NetworkCredential credenciales = new NetworkCredential(Usuario, contraseña);
            servidor.Credentials = credenciales;
            servidor.EnableSsl = true;

            try
            {
                servidor.Send(enviar);
                enviar.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
