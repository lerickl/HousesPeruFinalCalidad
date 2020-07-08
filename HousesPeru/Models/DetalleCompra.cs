using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.Models
{
    public class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public string Monto { get; set; }
        public Boolean? Pago { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario usuarios { get; set; }
    }
}