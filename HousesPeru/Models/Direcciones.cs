using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.Models
{
    public class Direcciones
    {
        public int DireccionesId { get; set; }
        public string Ubicacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public int InmuebleId { get; set; }
        public Inmueble Inmueble { get; set; }



    }
}