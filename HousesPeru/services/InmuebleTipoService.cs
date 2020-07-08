using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface IInmuebleTipoService
    {
        IEnumerable<InmuebleTipo> getInmuebleTipos();
    }
    public class InmuebleTipoService:IInmuebleTipoService
    {
        private readonly HousesInPeruContext _db;
        public InmuebleTipoService(HousesInPeruContext _db) {
            this._db = _db;
        }

        public IEnumerable<InmuebleTipo> getInmuebleTipos()
        {
            var InmTipo=_db.InmuebleTipos.ToList();
            return InmTipo;

        }
    }

  
}