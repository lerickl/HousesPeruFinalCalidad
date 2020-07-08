using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface ICiudadService
    {
        IEnumerable<Ciudades> GetCiudades();
    }
    public class CiudadService:ICiudadService
    {
        private readonly HousesInPeruContext _db;
        public CiudadService(HousesInPeruContext _db) {
            this._db = _db;
        }

        public IEnumerable<Ciudades> GetCiudades()
        {
            var ciudades=_db.Ciudades.ToList();
            return ciudades;
        }
    }


}