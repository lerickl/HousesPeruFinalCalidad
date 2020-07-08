using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface ISessionService
    {
        void GuardarSession(Usuario usuario);
        void LimpiarSession();
        bool IsLogged();
        bool EsAdmin();
        bool EsAgente();
        bool EsUsuario();
        bool EsSuSession(int? IdUsuario);
        int ConvertirSessionIdAIntId();
        void GuardarInmuebleEnSession(List<Inmueble> inmuebles);
        List<Inmueble> RetornarInmuebleDeSession();
    }
    public class SessionService:ISessionService
    {
        private readonly HttpContext contexto;
        private readonly UsuarioService UserServ;
        public SessionService() {
            contexto = HttpContext.Current;
            HousesInPeruContext conexion = new HousesInPeruContext();
            UserServ = new UsuarioService(conexion);
        }
        public void GuardarSession(Usuario usuario)
        {
            contexto.Session["UsuarioId"]= usuario.UsuarioId.ToString();
            contexto.Session["Nombre"] = usuario.Nombre.ToString();
            contexto.Session["ApellidoP"] = usuario.ApellidoP.ToString();
            contexto.Session["TipoUsuario"] = usuario.TipoUsuario.ToString();
            contexto.Session["Contador"] =null;

        }
        public void LimpiarSession() {
            contexto.Session.Clear();
        }
        public bool IsLogged()
        {
            if (contexto.Session["UsuarioId"] != null && contexto.Session["TipoUsuario"] != null)
                return true;
            return false;
        }
        public bool EsAdmin() 
        {
            if (IsLogged())
            { 
                int UsuarioId= Convert.ToInt32(contexto.Session["UsuarioId"]);
                Usuario usuario = UserServ.GetUsuarioByID(UsuarioId);
                if (usuario.TipoUsuario == "ADMINISTRADOR")
                    return true;

            }return false;

        }
        public bool EsAgente()
        {
            if (IsLogged())
            {
                int UsuarioId = Convert.ToInt32(contexto.Session["UsuarioId"]);
                Usuario usuario = UserServ.GetUsuarioByID(UsuarioId);
                if (usuario.TipoUsuario == "AGENTE")
                    return true;

            }
            return false;

        }
        public bool EsUsuario()
        {
            if (IsLogged())
            {
                int UsuarioId = Convert.ToInt32(contexto.Session["UsuarioId"]);
                Usuario usuario = UserServ.GetUsuarioByID(UsuarioId);
                if (usuario.TipoUsuario == "USUARIO")
                    return true;

            }
            return false;

        }
        public bool EsSuSession(int? IdUsuario)
        {
            if (IsLogged())
            {
                int UsuarioId = Convert.ToInt32(contexto.Session["UsuarioId"]);
                if (UsuarioId != IdUsuario)
                    return false;
            }
            return true;

        }
        public int ConvertirSessionIdAIntId()
        {
            int UsuarioId = Convert.ToInt32(contexto.Session["UsuarioId"]);
            return UsuarioId;
        }
        public void GuardarInmuebleEnSession(List<Inmueble> inmuebles)
        {
            contexto.Session["Inmueble"] = inmuebles;
        }
        public List<Inmueble> RetornarInmuebleDeSession()
        {
            List<Inmueble> inmuebles = (List<Inmueble>)contexto.Session["Inmueble"];
            return inmuebles;
        }



    }

 
}