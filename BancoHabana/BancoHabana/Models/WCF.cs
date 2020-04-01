using System;
using System.Collections.Generic;
using System.Linq;
using WcfToDb;

namespace BancoHabana.Models
{
    public class WCF
    {
        public String montoagua;
        public String fechaagua;
        public void agua(String cedula)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();



            string monto;
            monto = service.FacturaAgua(cedula);

            if (monto != " ")
            {
                String[] ArraySabadoI = monto.Split(',');
                montoagua = ArraySabadoI[0];
                fechaagua = ArraySabadoI[1];
            }
            else
            {
                montoagua = "error";
            }
            

        }
        public String montointernet;
        public String fechainternet;

        public void internet(String cedula)
        {
            ServiceReference2.Service1Client service = new ServiceReference2.Service1Client();

            string monto;
            
            monto = service.FacturaInternet(cedula);

            if (monto != " ")
            {
                String[] ArraySabadoI = monto.Split(',');

                montointernet = ArraySabadoI[0];
                fechainternet = ArraySabadoI[1];
            }
            else
            {
                montointernet = "error";
            }

            
        }

        public String consumokolbi;

        public String consumomovistar;

        public String consumoclaro;

        public String consumointernet;

        public String montotelefono;

        



        public void telefono(String celular)
        {
            ServiceReference3.Service1Client service = new ServiceReference3.Service1Client();

            string monto;
            
            monto = service.FacturaTelefono(celular);

            if (monto != " ")
            {
                String[] ArraySabadoI = monto.Split(',');

                consumokolbi = ArraySabadoI[0];
                consumomovistar = ArraySabadoI[1];
                consumoclaro = ArraySabadoI[2];

                consumointernet = ArraySabadoI[4];
                montotelefono = ArraySabadoI[5];
            }
            else
            {
                montotelefono = "error";
            }

            
        }

        public String montoluz;
        public String fechaluz;

        public void luz(String dato)
        {
            ServiceReference4.Service1Client service = new ServiceReference4.Service1Client();

            string monto;

            monto = service.FacturaLuz(dato);

            if (monto != " ")
            {
                String[] ArraySabadoI = monto.Split(',');

                montoluz = ArraySabadoI[0];
                fechaluz = ArraySabadoI[1];
            }
            else
            {
                montoluz = "error";
            }

            
            

            
        }

        public void recarga(String numero,String monto)
        {
            ServiceReference5.Service1Client service = new ServiceReference5.Service1Client();

            service.RecargaKolbi(numero, monto);

            


        }

    }
}