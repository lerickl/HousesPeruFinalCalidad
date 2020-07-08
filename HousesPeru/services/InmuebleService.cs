using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HousesPeru.services
{
    public interface IInmuebleService
    {
        void AddInmueble(Inmueble inmueble);
        IEnumerable<Inmueble> GetInmubles();
        Inmueble GetInmuebleById(int idInmueble);
        IEnumerable<Inmueble> GetInmueblesByUsuario(int UsuarioId);

        IEnumerable<Inmueble> BuscarInmueble(int ciudad, int TipoInmueble, string Estado);
        void EditarInmueble(int idInmueble, Inmueble inmueble);
    }
    public class InmuebleService:IInmuebleService
    {
        HousesInPeruContext _db;
        public InmuebleService(HousesInPeruContext _db) {
            this._db = _db;
        }
        public void AddInmueble(Inmueble inmueble)
        {
 
            _db.Inmuebles.Add(inmueble);
            _db.SaveChanges();
        }

        public IEnumerable<Inmueble> BuscarInmueble(int ciudad, int TipoInmueble, string Estado)
        {
            var inmuebles = new Inmueble(); 
            if (ciudad!=0 && TipoInmueble==0 && Estado=="0") {
                return _db.Inmuebles.Where(x => x.CiudadId == ciudad).ToList();
            }
            if (ciudad != 0 && TipoInmueble != 0 && Estado == "0") {
                return _db.Inmuebles.Where(x => x.InmuebleTipoId == TipoInmueble && x.InmuebleTipoId== TipoInmueble).ToList();
            }
            if (ciudad != 0 && TipoInmueble != 0 && Estado != "0")
            {
                if (Estado == "Alquiler") {
                    return _db.Inmuebles.Where(x => x.CiudadId == ciudad && x.InmuebleTipoId == TipoInmueble && x.PrecioAlquilerInm != null).ToList();
                } else {
                    return _db.Inmuebles.Where(x => x.CiudadId == ciudad && x.InmuebleTipoId == TipoInmueble && x.PrecioVentaInm != null).ToList();
                }
                
            }
            if (ciudad == 0 && TipoInmueble != 0 && Estado == "0")
            {
                return _db.Inmuebles.Where(x => x.InmuebleTipoId == TipoInmueble).ToList();
            }
            if (ciudad == 0 && TipoInmueble != 0 && Estado != "0")
            {
                if (Estado == "Alquiler")
                {
                    return _db.Inmuebles.Where(x=> x.InmuebleTipoId == TipoInmueble && x.PrecioAlquilerInm != null).ToList();
                }
                else
                {
                    return _db.Inmuebles.Where(x => x.InmuebleTipoId == TipoInmueble && x.PrecioVentaInm != null).ToList();
                }
            }
            if (ciudad == 0 && TipoInmueble == 0 && Estado != "0")
            {
                if (Estado == "Alquiler")
                {
                    return _db.Inmuebles.Where(x => x.PrecioAlquilerInm != null).ToList();
                }
                else
                {
                    return _db.Inmuebles.Where(x => x.PrecioVentaInm != null).ToList();
                }
            }
           
            
                return _db.Inmuebles.ToList(); 
            

         
        }

        public void EditarInmueble(int idInmueble, Inmueble inmueble)
        {
            var inm = _db.Inmuebles.Where(x=>x.InmuebleId== idInmueble).FirstOrDefault();
            inm.CiudadId = inmueble.CiudadId;
            inm.InmuebleTipoId = inmueble.InmuebleTipoId;
            inm.NombreInm = inmueble.NombreInm;
            inm.Area = inmueble.Area;
            inm.NumHabitaciones = inmueble.NumHabitaciones;
            inm.Pisos = inmueble.Pisos;
            inm.Piso = inmueble.Piso;
            inm.PrecioVentaInm = inmueble.PrecioVentaInm;
            inm.PrecioAlquilerInm = inmueble.PrecioAlquilerInm;
            inm.UbicacionInm = inmueble.UbicacionInm;
            inm.Baños = inmueble.Baños;
            inm.Garages = inmueble.Garages;
            inm.Descripcion = inmueble.Descripcion;
            inm.NumCelular = inmueble.NumCelular;
            inm.Moneda = inmueble.Moneda;


            _db.SaveChanges();
        }

        public IEnumerable<Inmueble> GetInmubles()
        {
            return _db.Inmuebles.ToList().OrderByDescending(x=>x.InmuebleId);

        }

        public Inmueble GetInmuebleById(int idInmueble)
        {
            return _db.Inmuebles.Where(x=>x.InmuebleId == idInmueble).FirstOrDefault();
        }

        public IEnumerable<Inmueble> GetInmueblesByUsuario(int UsuarioId)
        {

            return _db.Inmuebles.Where(x => x.UsuarioId == UsuarioId).ToList();
     
        }
    }


}