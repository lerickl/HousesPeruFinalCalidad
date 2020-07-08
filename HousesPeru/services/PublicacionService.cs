using HousesPeru.DB;
using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface IPublicacionService
    {
        void addPublicacion(Usuario user);
        //void addPublicacionAdminOrAgente(Usuario user);
   
        //IEnumerable<Publicacion> GetPublicacions();

    }
    public class PublicacionService:IPublicacionService
    {
        readonly HousesInPeruContext db;
        public PublicacionService(HousesInPeruContext db)
        {
            this.db = db;
        }



        public void addPublicacion(Usuario user)
        {
            //if (user.PlanId == 1)
            //{

            //    //publicacion.FechaInicio = DateTime.Now;
            //    user.FechaFinPlan = user.FechaInicioPlan.AddMonths(1);

            //}
            //if (user.PlanId == 2)
            //{

            //    //publicacion.FechaInicio = DateTime.Now;
            //    user.FechaFinPlan = user.FechaInicioPlan.AddMonths(6);

            //}
            //if (user.PlanId == 3)
            //{

            //    //publicacion.FechaInicio = DateTime.Now;
            //    user.FechaFinPlan = user.FechaInicioPlan.AddMonths(12);

            //}
            //publicacion.UsuarioId= IDUser;
            //db.Publicacions.Add(publicacion);
            //db.SaveChanges();
        }


    }


}