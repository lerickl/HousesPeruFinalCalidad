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
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private readonly IUsuarioService UserServ;
        private readonly IValidacionUsuario val;
        private readonly IAuthService auth;
        private readonly IInmuebleService InmServ;
        private readonly IImageService ImagenServ;
        private readonly ICloudinaryService Cloudserv;
        public UsuarioController(IUsuarioService UserServ, IValidacionUsuario val, IAuthService auth, IInmuebleService InmServ, IImageService ImagenServ, ICloudinaryService Cloudserv)
        {
            this.UserServ = UserServ;
            this.val = val;
            this.auth = auth;
            this.InmServ = InmServ;
            this.ImagenServ = ImagenServ;
            this.Cloudserv = Cloudserv;
        }
       

        [HttpGet]
        public ActionResult RegistroAgente()
        {
            var user = auth.GetLogedUser();
    
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
                if (user.TipoUsuario == "ADMINISTRADOR")
                {

                    return View();
                }
            }          
            ViewBag.UserLogged = null;
            return RedirectToAction("Index", "Home");
         
          
          
        }
        [HttpPost]
        public ActionResult RegistroAgente(UsuarioViewModel user)
        {
            var userlog = auth.GetLogedUser();
            if (userlog.TipoUsuario=="ADMINISTRADOR") {
                val.validarUsuario(user, ModelState);
                if (ModelState.IsValid)
                {
                    UserServ.AddUsuarioAgente(user);
                    return RedirectToAction("Index", "Home");
                }
                return View(user);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult ListaUsuarios()
        {
            var users = auth.GetLogedUser();
            if (users.TipoUsuario == "ADMINISTRADOR")
            {
                var usr = UserServ.GetUsuarios();
                return View(usr);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult ListaAgentes()
        {
            var users = auth.GetLogedUser();
            if (users.TipoUsuario == "ADMINISTRADOR")
            {
                var usr = UserServ.GetAgentes();
                return View(usr);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult GetUser() {
            var user = auth.GetLogedUser();
            var userTemp= UserServ.GetUsuarioByID(user.UsuarioId);
            ViewBag.Usuario = userTemp;
            ViewBag.UserLogged = user.TipoUsuario;
       
            var dato= Convert.ToDateTime(userTemp.FechaNacimiento.ToString());
            ViewBag.FechaNacimiento = dato.ToString("yyyy-MM-dd");
 
            return View();
        }
        [HttpPost]
        public ActionResult GetUser(Usuario usuario, HttpPostedFileBase imgperfil )
        {
            var user = auth.GetLogedUser();
            if (imgperfil != null) {
                string img = Cloudserv.uploadImg(imgperfil);
                usuario.ImagenPerfil = img;
            }
            val.valUsr(usuario,ModelState);
          
            if (ModelState.IsValid) {
                UserServ.EditarUsuario(user.UsuarioId, usuario);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.UserLogged = user.TipoUsuario;
            return View();
        }
    }
}
