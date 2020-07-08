using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.ViewModels
{
    public class InmuebleViewModel
    {
        public string NombreInm { get; set; }
        public string Area { get; set; }
        public string NumHabitaciones { get; set; }
        public string Pisos { get; set; }
        public string Piso { get; set; }
        public string PrecioVentaInm { get; set; }
        public string PrecioAlquilerInm { get; set; }
        public string UbicacionInm { get; set; }
        public DateTime? FechaPublic { get; set; }

        public string Descripcion { get; set; }
        public Boolean? EstaActivo { get; set; }

        public HttpPostedFileBase img1 { get; set; }
        public HttpPostedFileBase img2 { get; set; }
        public HttpPostedFileBase img3 { get; set; }
        public HttpPostedFileBase img4 { get; set; }
        public HttpPostedFileBase img5 { get; set; }

    }
}