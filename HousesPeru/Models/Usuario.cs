using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sexo { get; set; }
        public string TipoUsuario { get; set; }
        public string ImagenPerfil { get; set; }
        
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInicioPlan { get; set; }
        public DateTime? FechaFinPlan { get; set; }
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public virtual List<Inmueble> Inmuebles { get; set; }
        public virtual List<DetalleCompra> DetalleCompras { get; set; }
    }
}
