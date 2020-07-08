using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.Models
{
    public class Ciudades
    {
        public int CiudadesId { get; set; }
        public string Nombre { get; set; }

        public List<Inmueble> Inmuebles { get; set; }
    }
}