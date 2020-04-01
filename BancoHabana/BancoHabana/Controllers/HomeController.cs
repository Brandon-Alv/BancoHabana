using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoHabana.Models;

namespace BancoHabana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult opciones()
        {

            return View();
        }

        public ActionResult cambiarpass()
        {


            return View();

        }

        public ActionResult postcambiarpass()
        {
           
           
            string contra = Request.Form["contra"].ToString();
            string contra1 =Request.Form["contra2"].ToString();

            if (contra == contra1)
            {
                Procesos pr = new Procesos();
                pr.newpass(Session["correoR"].ToString(), contra);
                
                return View("login");
            }
            else
            {
                return View("cambiarpass"); //si no son iguales puede ir a otra pagina
            }

          
        }

        public ActionResult postRecuperacionToken()
        {
            
            string correo1 = Request.Form["correo"].ToString();
            string correo = Request.Form["correo"].ToString();
            string token = Request.Form["token"].ToString();

            Session["correoR"] = correo;

            Procesos pr = new Procesos();
            pr.ValidarToken(token, correo);

            if (pr.val == "Correcto")
            {
                return View("cambiarpass");
            }
            else
            {
                return View("RecuperacionToken");
            }

            
        }

        public ActionResult postopciones()
        {
            
            string correo = Request.Form["correo"].ToString();

            ViewData["correoRecuperacion"] = correo;

            Procesos pr = new Procesos();

            pr.GenerarToken(correo);

            return View("RecuperacionToken");

            
        }

        public ActionResult RecuperacionToken()
        {
            return View();
        }



            public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Login()
        {
            return View();
        }


        public ActionResult postLogin()
        {
            Procesos pr = new Procesos();

            string cedula = Request.Form["cedula"].ToString();
            string contraseña = Request.Form["contraseña"].ToString();

            Session["cedula"] = cedula;
            Session["correo"]= pr.Login(cedula, contraseña);

            if (pr.Log=="Correcto")
            {
                
                return View("Token");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Token()
        {
            return View();
        }

        public ActionResult postToken()
        {
            Procesos pr = new Procesos();
            string Token = Request.Form["token"].ToString();
            string correo = Session["correo"].ToString();
            pr.ValidarToken(Token, correo);

            if (pr.val == "Correcto")
            {
                return View("MenuPrincipal");
            }
            else
            {
                return View("Token");
            }
        }

        public ActionResult MenuPrincipal()
        {
            return View();
        }


        //MenuProductos

        public ActionResult MenuProductos()
        {
            return View();
        }

        public ActionResult Prestamos()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            cuen = p.getCuentas(Session["cedula"].ToString());

            Session["Cuentas"] = cuen;

            return View();
        }

        public ActionResult PostPrestamos()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            string cuenta = Request.Form["opcionesCuenta"].ToString();

            Session["cuentap"] = cuenta;

            Prestamos pr = new Prestamos();

            pr = p.getPrestamos(cuenta);

            Session["prestamos"] = pr;


            return View("DatosPrestamos");
        }

        //DatosPrestamos
        public ActionResult DatosPrestamos()
        {
            return View();
        }
        //

        public ActionResult Tarjetas()
        {
            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();

            List<BancoHabana.Models.Tarjetas> cuen = new List<BancoHabana.Models.Tarjetas>();

            string cuenta = Request.Form["opcionesCuenta"].ToString();

           

            cuen = p.getTarjetas(cuenta);

            Session["tarjetas"] = cuen;

            return View();
        }

        public ActionResult TarjetasCuenta()
        {
            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            cuen = p.getCuentas(Session["cedula"].ToString());
            
            Session["Cuentas"] = cuen;

            return View();
        }



        public ActionResult postTarjetas()
        {
            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Tarjetas> cuen = new List<BancoHabana.Models.Tarjetas>();

            string cuenta = Request.Form["opcionesTarjeta"].ToString();

            Session["tarjetaelegida"] = cuenta;

            Tarjetas pr = new Tarjetas();

            pr = p.getDatosTarjetas(cuenta);

            Session["tarjetasdatos"] = pr;

            return View("DatosTarjetas");
        }



        //DatosTarjetas

        public ActionResult DatosTarjetas()
        {
            return View();
        }

        //

        public ActionResult Cuentas()
        {
             BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            cuen = p.getCuentas(Session["cedula"].ToString());

            Session["Cuentas"] = cuen;

            return View();
        }

        public ActionResult pagoluz()
        {
            string montointernet = Request.Form["opcionesTarjeta"].ToString();

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();

            p.AumentarCuenta(Session["montointernet"].ToString(), montointernet);

            p.AgregarMovimiento(Session["montointernet"].ToString(), montointernet);
            ViewBag.Error = "Servicio Pagado con Exito";
            return View("MenuPrincipal");
        }

        public ActionResult pagointernet()
        {
            string montointernet = Request.Form["opcionesTarjeta"].ToString();

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();

            p.AumentarCuenta(Session["montointernet"].ToString(), montointernet);

            p.AgregarMovimiento(Session["montointernet"].ToString(), montointernet);

            ViewBag.Error = "Servicio Pagado con Exito";

            return View("MenuPrincipal");
        }

        public ActionResult pagarinternet()
        {
            string montointernet = Request.Form["montointernet"].ToString();

            Session["montointernet"] = montointernet;

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();

            List<BancoHabana.Models.Tarjetas> cuen = new List<BancoHabana.Models.Tarjetas>();

            



            cuen = p.getTodasTarjetas(Session["cedula"].ToString());

            Session["tarjetasinternet"] = cuen;


            String dato;

                foreach (var item in cuen)
                {
                dato = item.numtargeta;
                 }
            


            return View();
        }

        public ActionResult pagarluz()
        {
            string montointernet = Request.Form["montointernet"].ToString();

            Session["montointernet"] = montointernet;

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();

            List<BancoHabana.Models.Tarjetas> cuen = new List<BancoHabana.Models.Tarjetas>();





            cuen = p.getTodasTarjetas(Session["cedula"].ToString());

            Session["tarjetasluz"] = cuen;

            return View();
        }

        public ActionResult befluz()
        {

            string cuenta = Request.Form["numIdetificacion1"].ToString();
            BancoHabana.Models.WCF w = new WCF();
            w.luz(cuenta);

            if(Session["opcionluz"].ToString() == "jasec")
            {
                if (w.montoluz == "error")
                {
                    Session["mensaje"] = "El numero de servicio no tiene facturas pendientes";
                    return View("SolicitudLuz");
                }
                else
                {
                    Session["montoluz"] = w.montoluz;
                    Session["fechaluz"] = w.fechaluz;



                    return View("Luz");
                }
            }
            else
            {
                Session["mensaje1"] = "El Servicio de no esta en funcionamiento";
                return View("SolicitudLuz");
            }

            

            
        }

     

        //DatosCuentas
        public ActionResult DatosCuentas()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            string cuenta = Request.Form["opcionesCuenta"].ToString();

            Session["cuentap"] = cuenta;

            Cuentas pr = new Cuentas();

            pr = p.getDatosCuentas(cuenta);

            Session["cuentasdatos"] = pr;


            return View();
        }

        //

        //


        //MenuTransaccional
        public ActionResult MenuTransaccional()
        {
            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            cuen = p.getCuentas(Session["cedula"].ToString());

            Session["Cuentas"] = cuen;

            return View();
        }


        public ActionResult DatosMovimientos()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Movimientos> cuen = new List<BancoHabana.Models.Movimientos>();

            string cuenta = Request.Form["opcionesCuenta"].ToString();

            Session["cuentap"] = cuenta;

            Movimientos pr = new Movimientos();

            cuen = p.getDatosMovimientos(cuenta);

            Session["datosmovimientos"] = cuen;

            return View();
        }

        //



        //MenuServicios
        public ActionResult MenuServicios()
        {
            return View();
        }

        public ActionResult MenuAgua()
        {
            Session["mensaje"] = "";
            Session["mensaje1"] = "";
            return View();
        }

        public ActionResult SolicitudAgua()
        {

            string cuenta = Request.Form["opcionesAgua"].ToString();
            Session["opcionagua"] = cuenta;

            


            return View();
        }

        //

        public ActionResult befagua()
        {
            string cuenta = Request.Form["numIdetificacion1"].ToString();
            BancoHabana.Models.WCF w = new WCF();
            w.agua(cuenta);

            if(Session["opcionagua"].ToString() == "AyA")
            {
                if (w.montoagua == "error")
                {
                    Session["mensaje"] = "El numero de servicio no tiene facturas pendientes";
                    return View("SolicitudAgua");
                }
                else
                {
                    Session["montoagua"] = w.montoagua;
                    Session["fechaagua"] = w.fechaagua;
                    return View("Agua");
                }
            }
            else
            {
                Session["mensaje1"] = "El servicio no esta en funcionamiento";
                return View("SolicitudAgua");
            }
           
            
            

            
        }


        public ActionResult Agua()
        {
            

            return View();
        }
        //

        public ActionResult MenuLuz()
        {
            Session["mensaje"] = "";
            Session["mensaje1"] = "";
            return View();
        }

        public ActionResult SolicitudLuz()
        {

            string cuenta = Request.Form["opcionesLuz"].ToString();
            Session["opcionluz"] = cuenta;


            return View();
        }

        public ActionResult hacerrecarga()
        {

            string numero = Request.Form["numero"].ToString();
            string monto = Request.Form["monto"].ToString();

            BancoHabana.Models.WCF w = new WCF();
           w.recarga(numero,monto);

            return View("MenuPrincipal");
        }

        //
        public ActionResult Luz()
        {
            return View();
        }
        //

        public ActionResult MenuInternet()
        {
            Session["mensaje"] = "";
            Session["mensaje1"] = "";
            return View();
        }

        public ActionResult SolicitudInternet()
        {
            string cuenta = Request.Form["opcionesTelefono"].ToString();
            Session["opcioninternet"] = cuenta;

            return View();
        }

        

        public ActionResult befinternet()
        {

            string cuenta = Request.Form["numIdetificacion1"].ToString();
            BancoHabana.Models.WCF w = new WCF();
            w.internet(cuenta);

            if (Session["opcioninternet"].ToString() == "ICE")
            {
                if (w.montointernet == "error")
                {
                    Session["mensaje"] = "El numero de servicio no tiene facturas pendientes";
                    return View("SolicitudInternet");
                }
                else
                {
                    Session["montointernet"] = w.montointernet;
                    Session["fechainternet"] = w.fechainternet;

                    return View("internet");
                }
            }
            else
            {
                Session["mensaje1"] = "El servicio no esta en funcionamiento";
                return View("SolicitudInternet");
            }


            

           
        }

        //
        public ActionResult Internet()
        {



            return View();
        }
        //
        public ActionResult MenuTelefono()
        {
            Session["mensaje"] = "";
            Session["mensaje1"] = "";
            return View();
        }

        public ActionResult SolicitudTelefono()
        {

            string cuenta = Request.Form["opcionesTelefono"].ToString();
            Session["opciontelefono"] = cuenta;




            return View();
        }

        //
        public ActionResult Telefono()
        {
            return View();
        }

        public ActionResult beftelefono()
        {

            string cuenta = Request.Form["numIdetificacion1"].ToString();
            BancoHabana.Models.WCF w = new WCF();

            w.telefono(cuenta);


            if (Session["opciontelefono"].ToString() == "Kolbi")
            {
                if (w.montotelefono == "error")
                {
                    Session["mensaje"] = "El numero de servicio no tiene facturas pendientes";
                    return View("SolicitudTelefono");
                }
                else
                {
                    Session["consumokolbi"] = w.consumokolbi;
                    Session["consumomovistar"] = w.consumomovistar;
                    Session["consumoclaro"] = w.consumoclaro;
                    Session["consumointernet"] = w.consumointernet;
                    Session["monto"] = w.montotelefono;



                    return View("Telefono");
                }
            }
            else
            {
                Session["mensaje1"] = "El servicio no esta en funcionamiento";
                return View("SolicitudTelefono");
            }

            

            
        }



        public ActionResult MenuRecargas()
        {
            Session["mensaje"] = "";
            return View();
        }

        public ActionResult solicitudRecarga()
        {
            string cuenta = Request.Form["opcionesRecarga"].ToString();
            Session["opcionrecarga"] = cuenta;

            return View();
        }

        public ActionResult SolicitudTarjeta()
        {
            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Tarjetas> cuen = new List<BancoHabana.Models.Tarjetas>();

            cuen = p.getTodasTarjetas(Session["cedula"].ToString());

            Session["tarjetascliente"] = cuen;

            return View();
        }



        //

        //

        //Gestiones
        public ActionResult MenuGestiones()
        {
            return View();
        }

        public ActionResult ReposicionTarjetas()
        {
            return View();
        }
        public ActionResult EstadodeCuenta()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            string cuenta = Request.Form["opcionesCuenta"].ToString();

            Session["cuentap"] = cuenta;

            Cuentas pr = new Cuentas();

            pr = p.getDatosEstados(cuenta);

            Session["estadosdatos"] = pr;

            return View();
        }

        //Cuentas
        public ActionResult ElegirCuenta()
        {

            BancoHabana.Models.Procesos p = new BancoHabana.Models.Procesos();
            List<BancoHabana.Models.Cuentas> cuen = new List<BancoHabana.Models.Cuentas>();

            cuen = p.getCuentas(Session["cedula"].ToString());

            Session["Cuentas"] = cuen;

            return View();
        }
        
        //

        //

    }
}