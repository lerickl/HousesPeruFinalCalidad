using HousesPeru.Models;
using HousesPeru.services;
using HousesPeru.validaciones;
using HousesPeru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HousesPeru.Controllers
{
    public class InmuebleController : Controller
    {
        private readonly IAuthService AuthServ;
        private readonly IInmuebleService InmServ;
        private readonly IImageService ImagenServ;
        private readonly IInmuebleTipoService InmTipoServ;
        private readonly ICiudadService CiudadServ;
        private readonly IUsuarioService UsuarioServ;
        private readonly IPublicacionService PublicServ;
        private readonly IPlanService PlanServ;
        private readonly IValidacionInmueble valInm;

        // GET: Inmueble
        public InmuebleController(IAuthService AuthServ, IInmuebleService InmServ, IImageService ImagenServ, IInmuebleTipoService InmTipoServ, ICiudadService CiudadServ, IUsuarioService UsuarioServ, IPublicacionService PublicServ, IPlanService PlanServ, IValidacionInmueble valInm) {
            this.AuthServ = AuthServ;
            this.InmServ = InmServ;
            this.ImagenServ = ImagenServ;
            this.InmTipoServ = InmTipoServ;
            this.CiudadServ = CiudadServ;
            this.UsuarioServ = UsuarioServ;
            this.PublicServ = PublicServ;
            this.PlanServ = PlanServ;
            this.valInm = valInm;
        }

        [HttpGet]
        public ActionResult GetInmuebles()
        {
            var user = AuthServ.GetLogedUser();

            if (user != null)
            {
                if (user.TipoUsuario == "ADMINISTRADOR") {
                    ViewBag.UserLogged = user.TipoUsuario;
                    ViewBag.Usuarios = UsuarioServ.GetAllUsers();
                    ViewBag.Inmuebles = InmServ.GetInmubles();                
                    ViewBag.TipoInmueble = InmTipoServ.getInmuebleTipos();
                    ViewBag.Ciudad = CiudadServ.GetCiudades();
                    ViewBag.Plan = PlanServ.getPlans();

                }
                if (user.TipoUsuario == "USUARIO")
                {
                    ViewBag.UserLogged = user.TipoUsuario;
                    ViewBag.Usuarios = UsuarioServ.GetUsuarios();
                    ViewBag.Inmuebles = InmServ.GetInmueblesByUsuario(user.UsuarioId);                  
                    ViewBag.TipoInmueble = InmTipoServ.getInmuebleTipos();
                    ViewBag.Ciudad = CiudadServ.GetCiudades();
                    ViewBag.Plan = PlanServ.getPlans();
                }
                if (user.TipoUsuario == "AGENTE")
                {
                    ViewBag.UserLogged = user.TipoUsuario;
                    ViewBag.Usuarios = UsuarioServ.GetUsuarios();
                    ViewBag.Inmuebles = InmServ.GetInmueblesByUsuario(user.UsuarioId);             
                    ViewBag.TipoInmueble = InmTipoServ.getInmuebleTipos();
                    ViewBag.Ciudad = CiudadServ.GetCiudades();
                    ViewBag.Plan = PlanServ.getPlans();
                }

            }
            else
            {
                ViewBag.UserLogged = null;
            }
            return View();
        }
        [HttpGet]
        public ActionResult Buscar(string Estado) {
            var user = AuthServ.GetLogedUser();
            ViewBag.Inmuebles = InmServ.BuscarInmueble(0, 0, Estado);
            ViewBag.Imagenes = ImagenServ.GetImagenes();
            ViewBag.TipoInmueble = InmTipoServ.getInmuebleTipos();
            ViewBag.ciudad = CiudadServ.GetCiudades();
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
        [HttpPost]
        public ActionResult Buscar(int ciudad, int TipoInmueble, string Estado) {
            var user = AuthServ.GetLogedUser();

            var inmuebles = InmServ.BuscarInmueble(ciudad, TipoInmueble, Estado) ;
            var listImg = new List<Imagen>();
            foreach (var inm in inmuebles)
            {
                var imagen = ImagenServ.GetImagenesByInmuebleId(inm.InmuebleId);
                listImg.Add(imagen);

            }

            //ViewBag.Inmuebles = InmServ.BuscarInmueble(ciudad, TipoInmueble, Estado);
            ViewBag.Inmuebles=inmuebles;
            ViewBag.Imagenes = listImg;
            ViewBag.TipoInmueble = InmTipoServ.getInmuebleTipos();
            ViewBag.ciudad = CiudadServ.GetCiudades();
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
        public ActionResult Inmueble(int id)
        {
            var user = AuthServ.GetLogedUser();
            var inmueble= InmServ.GetInmuebleById(id);
        
            ViewBag.Inmueble =inmueble; 
            ViewBag.InmuebleTipo = InmTipoServ.getInmuebleTipos();
            ViewBag.Ciudades = CiudadServ.GetCiudades();
            ViewBag.Imagen = ImagenServ.GetAllImagenesByInmuebleID(inmueble.InmuebleId);
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
        //editar inm
        [HttpPost]
        public ActionResult Inmueble(Inmueble inmueble, int IdInmuebleTip, int IdCiudades, List<HttpPostedFileBase> Imagen) {

            var user = AuthServ.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;

                inmueble.UsuarioId = user.UsuarioId;
                inmueble.InmuebleTipoId = IdInmuebleTip;
                inmueble.CiudadId = IdCiudades;
                
                valInm.validarInmueble(inmueble, ModelState);
                if (ModelState.IsValid)
                {

                    InmServ.EditarInmueble(inmueble.InmuebleId, inmueble);
                    ImagenServ.AddImagen(Imagen, inmueble.InmuebleId);
                    return RedirectToAction("Index", "Home");

                }
                ViewBag.Inmueble= inmueble;
                ViewBag.InmuebleTipo = InmTipoServ.getInmuebleTipos();
                ViewBag.Ciudades = CiudadServ.GetCiudades();
                ViewBag.Imagen = ImagenServ.GetAllImagenesByInmuebleID(inmueble.InmuebleId);
                return View(inmueble);
            }
            else
            {
                ViewBag.UserLogged = null;
                return RedirectToAction("Index", "Home");
            }
       
        }
        [HttpPost]
        public JsonResult DelImg(int idImag) {

            ImagenServ.DelImg(idImag);
            return Json(true);
            //return Json(false);
        }
        [HttpGet]
        public JsonResult InmLayout() {
            var data = new List<JsonImagen>();
            data= ImagenServ.getAllImgs();
           
            return Json(data, JsonRequestBehavior.AllowGet );
        }
    }
}