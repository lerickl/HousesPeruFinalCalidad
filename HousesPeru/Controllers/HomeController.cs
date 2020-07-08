using HousesPeru.Models;
using HousesPeru.services;
using HousesPeru.validaciones;
using HousesPeru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousesPeru.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioService UserServ;
        private readonly IAuthService autentication;
        private readonly ISessionService session;
        private readonly IValidacionUsuario val;
        private readonly IInmuebleService InmServ;
        private readonly IImageService ImagenServ;
        private readonly IInmuebleTipoService inmuebleTipo;
        private readonly ICiudadService ciudadService;
        public HomeController(IUsuarioService UserServ, IAuthService autentication,ISessionService session, IValidacionUsuario val, IInmuebleService InmServ, IImageService ImagenServ, IInmuebleTipoService inmuebleTipo, ICiudadService ciudadService) 
        {
            this.UserServ = UserServ;
            this.autentication = autentication;
            this.session = session;
            this.val = val;
            this.InmServ = InmServ;
            this.ImagenServ = ImagenServ;
            this.inmuebleTipo = inmuebleTipo;
            this.ciudadService = ciudadService;

        }
  
        public ActionResult Index()
        {

            var inmuebles= InmServ.GetInmubles();
            var listImg = new List<Imagen>();
            foreach (var inm in inmuebles) {
                var imagen = ImagenServ.GetImagenesByInmuebleId(inm.InmuebleId);
                listImg.Add(imagen);

            } 
            ViewBag.Inmuebles = inmuebles;
            ViewBag.Imagenes = listImg;
            ViewBag.TipoInmueble = inmuebleTipo.getInmuebleTipos();
            ViewBag.ciudad = ciudadService.GetCiudades();

            var user = autentication.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
            }
            else
            {
                ViewBag.UserLogged = null;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(UsuarioViewModel user)
        {
            val.validarUsuario(user, ModelState);
            if (ModelState.IsValid) 
            {
                UserServ.AddUsuario(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {

            if (usuario.Email == "" || usuario.Password == "")
            {
   
                ViewBag.ShowModalLogin = true;
                ModelState.AddModelError("Cuenta", "Email o Password Incorrectos!");
                return View(usuario);

            }
            Usuario user = UserServ.GetUsuarioByEmailAndPassword(usuario.Email, usuario.Password);
            if (user != null)
            {
                autentication.Login(user);
                session.GuardarSession(user);
              
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("Index", "Home");
            }
           
          

        }
        public ActionResult LogOut() {
            autentication.Logout();
            session.LimpiarSession();
            return RedirectToAction("Index","Home");
        }
        public bool IsLogged() {
            if (Session["UsuarioId"] != null && Session["TipoUsuario"] != null)
                return true;
            return false;
        }
        [HttpGet]
        public ActionResult About()
        {        
            var user = autentication.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
            }
            else
            {
                ViewBag.UserLogged = null;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            var user = autentication.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
            }
            else
            {
                ViewBag.UserLogged = null;
            }
            return View();
        }
       
        
        //[HttpPost]
        //public ActionResult prueba(Inmueble inmueble, List<HttpPostedFileBase> ImagenPruebaId) {
 
        //    var imag = new List<HttpPostedFileBase>();

        //    foreach (var Img in ImagenPruebaId) {
        //        imag.Add(Img);
            
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult prueba()
        //{
        //    var inmuebles = InmServ.GetInmubles();
        //    var listImg = new List<Imagen>();
        //    foreach (var inm in inmuebles)
        //    {
        //        var imagen = ImagenServ.GetImagenesByInmuebleId(inm.InmuebleId);
        //        listImg.Add(imagen);

        //    } 
        //    ViewBag.Inmuebles = inmuebles;
        //    ViewBag.Imagenes = listImg;
        //    ViewBag.TipoInmueble = inmuebleTipo.getInmuebleTipos();
        //    ViewBag.ciudad = ciudadService.GetCiudades();

        //    var user = autentication.GetLogedUser();
        //    if (user != null)
        //    {
        //        ViewBag.UserLogged = user.TipoUsuario;
        //    }
        //    else
        //    {
        //        ViewBag.UserLogged = null;
        //    }
        //    return View();
        //}

    }
}