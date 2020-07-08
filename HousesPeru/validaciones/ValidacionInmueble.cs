using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HousesPeru.validaciones
{
    public interface IValidacionInmueble
    {
        void validarInmueble(Inmueble inmueble, ModelStateDictionary modelState);
    }
    public class ValidacionInmueble:IValidacionInmueble
    {
        private readonly HousesInPeruContext db;
        public ValidacionInmueble() { 
        
        }

        public void validarInmueble(Inmueble inmueble, ModelStateDictionary modelState)
        {
            modelState.Clear();
            string LetrasRegex = @"^[a-zA-Z\s]+$";
            string NumerosRegex = @"^(0|[1-9]\d*)$";
            string EmailRegex = @"^(('[\w-\s]+')|([\w-]+(?:\.[\w-]+)*)|('[\w-\s]+')([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)";
            if (string.IsNullOrEmpty(inmueble.NombreInm))
                modelState.AddModelError("Nombre", "El nombre es campo obligatorio!");
            if (string.IsNullOrEmpty(inmueble.NombreInm) || inmueble.NombreInm.Length <= 0)
                modelState.AddModelError("Nombre", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(inmueble.NombreInm) || inmueble.NombreInm.Length > 50)
                modelState.AddModelError("Nombre", "No puede tener mas de 50 caracteres");
            bool isNombreValid = string.IsNullOrEmpty(inmueble.NombreInm) || Regex.IsMatch(inmueble.NombreInm, LetrasRegex);
            if (!isNombreValid)
                modelState.AddModelError("Nombre", "Solo se aceptan letras");

            if (string.IsNullOrEmpty(inmueble.Descripcion))
                modelState.AddModelError("Descripcion", "La Descripcion es obligatoria!");
            if (string.IsNullOrEmpty(inmueble.Descripcion) || inmueble.Descripcion.Length <= 0)
                modelState.AddModelError("Descripcion", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(inmueble.Descripcion) || inmueble.Descripcion.Length > 200)
                modelState.AddModelError("Descripcion", "No puede tener mas de 200 caracteres");


            if (string.IsNullOrEmpty(inmueble.UbicacionInm))
                modelState.AddModelError("UbicacionInm", "La Ubicacion es obligatoria!");
            if (string.IsNullOrEmpty(inmueble.UbicacionInm) || inmueble.UbicacionInm.Length <= 0)
                modelState.AddModelError("UbicacionInm", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(inmueble.UbicacionInm) || inmueble.UbicacionInm.Length >100)
                modelState.AddModelError("UbicacionInm", "No puede tener mas de 100 caracteres");

        
            if (string.IsNullOrEmpty(inmueble.NumCelular))
                modelState.AddModelError("Telefono", "El Numero de Contacto es obligatorio!");
            if (string.IsNullOrEmpty(inmueble.NumCelular) || inmueble.NumCelular.Length <= 0)
                modelState.AddModelError("Telefono", "Tiene que tener al menos un caracter");
            if (string.IsNullOrEmpty(inmueble.NumCelular) || inmueble.NumCelular.Length > 9)
                modelState.AddModelError("Telefono", "No puede tener mas de 9 caracteres");
            bool isTelefonoValid = string.IsNullOrEmpty(inmueble.NumCelular) || Regex.IsMatch(inmueble.NumCelular, NumerosRegex);
            if (!isTelefonoValid)
                modelState.AddModelError("Telefono", "Solo se aceptan Numeros");

            if (!string.IsNullOrEmpty(inmueble.Area)) {
                if (inmueble.Area.Length > 50)
                    modelState.AddModelError("Area", "No puede tener mas de 50 caracteres");
                bool isAreaValid = Regex.IsMatch(inmueble.Area, NumerosRegex);
                if (!isAreaValid)
                    modelState.AddModelError("Area", "Solo se aceptan Numeros");
            }
            

            if (inmueble.InmuebleTipoId == 0)
                modelState.AddModelError("InmuebleTipo", "Debe elegir Tipo de Inmueble!");
            if (inmueble.CiudadId == 0)
                modelState.AddModelError("Ciudad", "Debe elegir una Ciudad!");

            if (inmueble.Moneda == "0")
            {
                modelState.AddModelError("Moneda", "Debe elegir el tipo de moneda");
            }

        }
    }

    
}