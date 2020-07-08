using HousesPeru.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HousesPeru.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        private readonly IAuthService autentication;
        private readonly IPlanService PlanServ;
        private readonly IUsuarioService userServ;
        
        public PlanController(IAuthService autentication, IPlanService PlanServ, IUsuarioService userServ) {
            this.autentication = autentication;
            this.PlanServ = PlanServ;
            this.userServ = userServ;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetPlanes() 
        {
            var user = autentication.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
                ViewBag.PlanActual = PlanServ.getPlanById(user.PlanId);
                ViewBag.User = userServ.GetUsuarioByID(user.UsuarioId);         
            }
            else
            {
                ViewBag.UserLogged = null;
                ViewBag.PlanActual = null;
                ViewBag.User = null;
            }
            return View();

        }
        [HttpPost]
        public ActionResult PostPlanes(int IdPlan)
        {
            var user = autentication.GetLogedUser();
            if (user != null)
            {
                ViewBag.UserLogged = user.TipoUsuario;
                ViewBag.PlanActual = PlanServ.getPlanById(user.PlanId);
                ViewBag.User = userServ.GetUsuarioByID(user.UsuarioId);
            }
            else
            {
                ViewBag.UserLogged = null;
                ViewBag.PlanActual = null;
                ViewBag.User = null;
            }
            return View();

        }
    }
}