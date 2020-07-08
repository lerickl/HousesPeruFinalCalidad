using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public virtual List<Usuario> Usuarios{ get; set; }
 
        //public Plan() {
        //    Usuarios = new List<Usuario>();
        //}
    
    }
}
