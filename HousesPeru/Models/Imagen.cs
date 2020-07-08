using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.Models
{
    public class Imagen
    {
        public int ImagenId { get; set; }
        
        public string Img { get; set; }
        
        public int InmuebleId { get; set; }
        public virtual Inmueble Inmuebles { get; set; }


    }
}
