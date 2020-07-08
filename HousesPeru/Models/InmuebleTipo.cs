using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.Models
{
    public class InmuebleTipo
    {
        public int InmuebleTipoId { get; set; }
        public string Nombre { get; set; }
 
        public virtual List<Inmueble> Inmuebles { get; set; }
    }
}
