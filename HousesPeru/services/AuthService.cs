using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HousesPeru.services
{
    public interface IAuthService
    {
        Usuario Login(Usuario usuario);
        void Logout();
        Usuario GetLogedUser();
    }
    public class AuthService : IAuthService
    {
        HousesInPeruContext context;
        public AuthService(HousesInPeruContext context) { 
        this.context=  context;
        }
        public Usuario GetLogedUser()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario user = context.Usuarios.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                HttpContext.Current.Session["Usuario"] = usuario;
                return user;

            };
            throw new NotImplementedException();

        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
        public struct User
        {
            public const string USUARIO = "usuario";
        }

    
    }


}