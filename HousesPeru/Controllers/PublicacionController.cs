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
    public class PublicacionController : Controller
    {
        // GET: Publicacion
        private readonly IAuthService auth;
        private readonly IPlanService PlanServ;
        private readonly IInmuebleTipoService InmTipServ;
        private readonly ICiudadService CiudServ;
        private readonly ICloudinaryService Cloudinary;
        private readonly IInmuebleService inmServ;
        private readonly IImageService ImagenServ;
        private readonly IPublicacionService publicServ;
        private readonly IValidacionInmueble valInm;
        public PublicacionController(IAuthService auth, IPlanService PlanServ, IInmuebleTipoService InmTipServ, ICiudadService CiudServ, ICloudinaryService Cloudinary, IInmuebleService inmServ, IImageService ImagenServ, IPublicacionService publicServ, IValidacionInmueble valInm) 
        {
            this.auth = auth;
            this.PlanServ = PlanServ;
            this.InmTipServ = InmTipServ;
            this.CiudServ = CiudServ;
            this.Cloudinary = Cloudinary;
            this.inmServ = inmServ;
            this.ImagenServ = ImagenServ;
            this.publicServ = publicServ;
            this.valInm = valInm;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPublicacion() {
         
            
            var user= auth.GetLogedUser();
      
 
            if (user != null)
            {
                ViewBag.Plans = PlanServ.getPlans();
                ViewBag.InmuebleTipo = InmTipServ.getInmuebleTipos();
                ViewBag.Ciudades = CiudServ.GetCiudades();
                ViewBag.UserLogged = user.TipoUsuario;
                return View(new Inmueble());
            }
            else
            {
                ViewBag.Plans = null;
                ViewBag.InmuebleTipo = null;
                ViewBag.Ciudades = null;
                ViewBag.UserLogged = null;
                return RedirectToAction("Index","Home");
            }

           
        }
        [HttpPost]
        public ActionResult AddPublicacion(Inmueble inmueble, int IdInmuebleTip, int IdCiudades, List<HttpPostedFileBase> Imagen)
        {

            var user = auth.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;

                inmueble.UsuarioId = user.UsuarioId;
                inmueble.InmuebleTipoId = IdInmuebleTip;
                inmueble.CiudadId = IdCiudades;
                inmueble.FechaPublic = DateTime.Now;
                valInm.validarInmueble(inmueble, ModelState);
                int temp = 0;
                foreach (var xd in Imagen)
                {
                    if (xd != null)
                    {
                        temp++;

                    }
                }
                if (temp == 0)
                {
                    ModelState.AddModelError("Imagenes", "Debe subir alguna Imagen");
                }

                if (ModelState.IsValid)
                {

                    inmServ.AddInmueble(inmueble);
                    ImagenServ.AddImagen(Imagen, inmueble.InmuebleId);
                    return RedirectToAction("Index", "Home");

                }
                ViewBag.Plans = PlanServ.getPlans();
                ViewBag.InmuebleTipo = InmTipServ.getInmuebleTipos();
                ViewBag.Ciudades = CiudServ.GetCiudades();
                ViewBag.Inmueble = inmueble;

                if (inmueble.Moneda == "0")
                {
                    inmueble.Moneda = "Seleccione Moneda";
                }
                ViewBag.InmuebleTipoSelect = IdInmuebleTip;
                ViewBag.CiudadesSelect = IdCiudades;
                return View(user);
            }
            else
            {
                ViewBag.UserLogged = null;
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpGet]
        public ActionResult GetInmuebleByID(int IdInmueble) {
            var user = auth.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
            }
            else {
                ViewBag.UserLogged = null;
            }
   
            var inmueble = inmServ.GetInmuebleById(IdInmueble);
            var inmuebles = inmServ.GetInmubles();
            var listImg = new List<Imagen>();
            foreach (var inm in inmuebles)
            {
                var imagen = ImagenServ.GetImagenesByInmuebleId(inm.InmuebleId);
                listImg.Add(imagen);


            }

            ViewBag.Inmueble = inmueble;
            ViewBag.InmuebleTipo = InmTipServ.getInmuebleTipos();
            ViewBag.Ciudades = CiudServ.GetCiudades();
            ViewBag.Imagenes = ImagenServ.GetAllImagenesByInmuebleID(inmueble.InmuebleId);

            ViewBag.AllImgInmuebles = listImg;
            ViewBag.Inmuebles = inmuebles;

            return View();
        }
        [HttpGet]
        public ActionResult Direcciones()
        {
            return View();
        }
    }
}