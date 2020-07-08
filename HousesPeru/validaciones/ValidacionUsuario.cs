using HousesPeru.DB;
using HousesPeru.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HousesPeru.Models;

namespace HousesPeru.validaciones
{
    public interface IValidacionUsuario
    {
        void validarUsuario(UsuarioViewModel user, ModelStateDictionary modelState);
        void valUsr(Usuario user, ModelStateDictionary modelState);
    }
    public class ValidacionUsuario : IValidacionUsuario
    {
        private readonly HousesInPeruContext db;
        public ValidacionUsuario(HousesInPeruContext db) 
        {
            this.db = db;
        }

        public void validarUsuario(UsuarioViewModel user, ModelStateDictionary modelState)
        {
            modelState.Clear();
            string LetrasRegex = @"^[a-zA-Z\s]+$";
            string NumerosRegex = @"^(0|[1-9]\d*)$";
            string EmailRegex = @"^(('[\w-\s]+')|([\w-]+(?:\.[\w-]+)*)|('[\w-\s]+')([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)";
            if (string.IsNullOrEmpty(user.Nombre))
                modelState.AddModelError("Nombre", "El nombre es campo obligatorio!");
            if (string.IsNullOrEmpty(user.Nombre) || user.Nombre.Length <= 0)
                modelState.AddModelError("Nombre", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.Nombre) || user.Nombre.Length > 100)
                modelState.AddModelError("Nombre", "No puede tener mas de 100 caracteres");
            bool isNombreValid = string.IsNullOrEmpty(user.Nombre) || Regex.IsMatch(user.Nombre, LetrasRegex);
            if (!isNombreValid)
                modelState.AddModelError("Nombre", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.ApellidoP))
                modelState.AddModelError("ApellidoP", "El apellido paterno es obligatorio!");
            if (string.IsNullOrEmpty(user.ApellidoP) || user.ApellidoP.Length <= 0)
                modelState.AddModelError("ApellidoP", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.ApellidoP) || user.ApellidoP.Length > 100)
                modelState.AddModelError("ApellidoP", "No puede tener mas de 100 caracteres");
            bool isApellidoPValid = string.IsNullOrEmpty(user.ApellidoP) || Regex.IsMatch(user.ApellidoP, LetrasRegex);
            if (!isApellidoPValid)
                modelState.AddModelError("ApellidoP", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.ApellidoM))
                modelState.AddModelError("ApellidoM", "El apellido materno es  obligatorio!");
            if (string.IsNullOrEmpty(user.ApellidoM) || user.ApellidoM.Length <= 0)
                modelState.AddModelError("ApellidoM", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.ApellidoM) || user.ApellidoM.Length > 100)
                modelState.AddModelError("ApellidoP", "No puede tener mas de 100 caracteres");
            bool isApellidoMValid = string.IsNullOrEmpty(user.ApellidoM) || Regex.IsMatch(user.ApellidoM, LetrasRegex);
            if (!isApellidoPValid)
                modelState.AddModelError("ApellidoP", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.Email))
                modelState.AddModelError("Email", "El Email es obligatorio!");
            if (string.IsNullOrEmpty(user.Email) || user.Email.Length <= 0)
                modelState.AddModelError("Email", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.Email) || user.Email.Length > 100)
                modelState.AddModelError("Email", "No puede tener mas de 100 caracteres");
            bool isEmailValid = string.IsNullOrEmpty(user.Email) || Regex.IsMatch(user.Email, EmailRegex);
            if (!isEmailValid)
                modelState.AddModelError("Email", "Ingrese un Email Correcto ");
            if (existeUserC(user.Email))
                modelState.AddModelError("Email","Ya existe un usuario con el mismo email");
            
            if (string.IsNullOrEmpty(user.Password))
                modelState.AddModelError("Password", "La contraseña es obligatorio!");
 
        }
        public bool existeUserC(string email)
        {
            var usrs = db.Usuarios.Where(x=>x.Email== email).FirstOrDefault();
   
            if (usrs != null)
            {
                return true;
            }return false;
       
                   
        }

        public void valUsr(Usuario user, ModelStateDictionary modelState)
        {
            modelState.Clear();
            string LetrasRegex = @"^[a-zA-Z\s]+$";
   
            string EmailRegex = @"^(('[\w-\s]+')|([\w-]+(?:\.[\w-]+)*)|('[\w-\s]+')([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)";
            if (string.IsNullOrEmpty(user.Nombre))
                modelState.AddModelError("Nombre", "El nombre es campo obligatorio!");
            if (string.IsNullOrEmpty(user.Nombre) || user.Nombre.Length <= 0)
                modelState.AddModelError("Nombre", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.Nombre) || user.Nombre.Length > 100)
                modelState.AddModelError("Nombre", "No puede tener mas de 100 caracteres");
            bool isNombreValid = string.IsNullOrEmpty(user.Nombre) || Regex.IsMatch(user.Nombre, LetrasRegex);
            if (!isNombreValid)
                modelState.AddModelError("Nombre", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.ApellidoP))
                modelState.AddModelError("ApellidoP", "El apellido paterno es obligatorio!");
            if (string.IsNullOrEmpty(user.ApellidoP) || user.ApellidoP.Length <= 0)
                modelState.AddModelError("ApellidoP", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.ApellidoP) || user.ApellidoP.Length > 100)
                modelState.AddModelError("ApellidoP", "No puede tener mas de 100 caracteres");
            bool isApellidoPValid = string.IsNullOrEmpty(user.ApellidoP) || Regex.IsMatch(user.ApellidoP, LetrasRegex);
            if (!isApellidoPValid)
                modelState.AddModelError("ApellidoP", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.ApellidoM))
                modelState.AddModelError("ApellidoM", "El apellido materno es  obligatorio!");
            if (string.IsNullOrEmpty(user.ApellidoM) || user.ApellidoM.Length <= 0)
                modelState.AddModelError("ApellidoM", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.ApellidoM) || user.ApellidoM.Length > 100)
                modelState.AddModelError("ApellidoP", "No puede tener mas de 100 caracteres");
            bool isApellidoMValid = string.IsNullOrEmpty(user.ApellidoM) || Regex.IsMatch(user.ApellidoM, LetrasRegex);
            if (!isApellidoPValid)
                modelState.AddModelError("ApellidoP", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(user.Email))
                modelState.AddModelError("Email", "El Email es obligatorio!");
            if (string.IsNullOrEmpty(user.Email) || user.Email.Length <= 0)
                modelState.AddModelError("Email", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(user.Email) || user.Email.Length > 100)
                modelState.AddModelError("Email", "No puede tener mas de 100 caracteres");
            bool isEmailValid = string.IsNullOrEmpty(user.Email) || Regex.IsMatch(user.Email, EmailRegex);
            if (!isEmailValid)
                modelState.AddModelError("Email", "Ingrese un Email Correcto ");
            //if (existeUserC(user.Email))
            //    modelState.AddModelError("Email", "Ya existe un usuario con el mismo email");

           
        }
    }


}